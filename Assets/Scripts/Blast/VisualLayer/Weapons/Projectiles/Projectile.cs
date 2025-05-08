using System;
using Blast.VisualLayer.Components;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Weapons.Projectiles
{
	public class Projectile : MonoBehaviour, IPoolable<Vector3, Vector3, IMemoryPool>
	{
		#region Factory
		
		public class Factory : PlaceholderFactory<Vector3, Vector3, Projectile>
		{
			
		}
		
		#endregion

		#region Editor

		[SerializeField]
		private Rigidbody _rb;

		#endregion
		
		#region Injections

		[Inject(Id = WeaponsBindingIds.MuzzleFlashVfxPrefabRef)] 
		private GameObject _muzzleFlashVfxPrefabRef;
		
		[Inject(Id = WeaponsBindingIds.MuzzleFlashVfxPrefabRef)]  
		private GameObject _collisionVfxPrefabRef;
		
		#endregion
		
		#region Fields

		private Vector3 _launchingPosition;

		private Quaternion _directionRotation;

		private float _speed;

		private float _maxDistance;

		private int _damage;
		
		private IMemoryPool _memoryPool;
		
		#endregion
		
		#region Methods

		private void Awake()
		{
			gameObject.SetActive(false); //היה באג של שגיאה בגישה לפרוגקטייל ולכבות אותו פה  עזר לזה
		}

		public void OnSpawned(Vector3 launchingPosition, Vector3 direction, IMemoryPool memoryPool)
		{
			gameObject.SetActive(true);
			_launchingPosition = launchingPosition;
			_directionRotation = Quaternion.LookRotation(direction);
			transform.SetPositionAndRotation(_launchingPosition, _directionRotation);
			_memoryPool = memoryPool;
		}
		
		public void OnDespawned()
		{
			gameObject.SetActive(false);
			_speed = 0;
			_directionRotation = Quaternion.identity;
			_rb.velocity = Vector3.zero;
		}

		public void Fire(float speed, float maxDistance, int damage)
		{
			_speed = speed;
			_maxDistance = maxDistance;
			_damage = damage;
			PlayMuzzleEffect(_launchingPosition, _directionRotation);
			_rb.velocity = transform.forward * _speed;
		}

		private void FixedUpdate()
		{
			ValidateMaxDistance();
		}

		private void ValidateMaxDistance()
		{
			if (Vector3.Distance(_launchingPosition, transform.position) > _maxDistance)
			{
				_memoryPool.Despawn(this);
			}
		}

		private void OnCollisionEnter(Collision other)
		{
			PlayCollisionEffectAt(other.contacts[0]);
			var damageable = other.gameObject.GetComponent<IDamageable>();
			damageable?.Damage(_damage);
			_memoryPool.Despawn(this);
		}

		private void PlayMuzzleEffect(Vector3 effectPosition, Quaternion effectRotation)
		{
			Instantiate(_muzzleFlashVfxPrefabRef, effectPosition, effectRotation);
		}

		private void PlayCollisionEffectAt(ContactPoint contactPoint)
		{
			var hitPoint = contactPoint;
			Instantiate(_collisionVfxPrefabRef, hitPoint.point, Quaternion.LookRotation(hitPoint.normal));
		}

		#endregion
	}
}