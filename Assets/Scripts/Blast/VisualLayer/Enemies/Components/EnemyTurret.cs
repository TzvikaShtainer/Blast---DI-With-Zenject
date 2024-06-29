using Blast.VisualLayer.Components;
using UnityEngine;

namespace Blast.VisualLayer.Enemies.Components
{
	// TODO: Add [RequireComponent]
	public class EnemyTurret : MonoBehaviour
	{
		#region Factories
		#endregion
		
		#region Editor

		[SerializeField]
		[Range(1, 100)]
		private float _rotationSpeed;

		[SerializeField]
		private float _lockAnglePrecision = 5;
		
		// [SerializeField]
		// private AutomaticWeaponTrigger _weaponTrigger;
		
		#endregion
		
		#region Fields

		private Damageable _damageable;
		
		private bool _prevFrameIsLockOnTarget;
		
		#endregion
		
		#region Methods

		private void OnGameEnd()
		{
			//_weaponTrigger.enabled = false;
			enabled = false;
		}

		private void Awake()
		{
			_damageable = GetComponent<Damageable>();
			// TODO: Subscribe to GameEnd signal
		}

		private void Start()
		{
			_damageable.DamageReceived += OnDamageReceived;
			_damageable.Destroyed += OnDestroyed;
		}

		private void OnDestroy()
		{
			_damageable.DamageReceived -= OnDamageReceived;
			_damageable.Destroyed -= OnDestroyed;
		}

		private void OnDamageReceived(int receivedDamage)
		{
			// TODO: Raise notification EnemyTurretHit
		}

		private void OnDestroyed()
		{
			// TODO: Raise notification EnemyTurretDestroyed
		}

		private void Update()
		{
			HandleLookOnTarget();
		}

		private void HandleLookOnTarget()
		{
			// TODO: Implement IEnemyTarged
			// SmoothLookOnTarget();
			// var isLockedOnTargetNow = GetIsLockedOnTargetNow();
			
			// TODO: Implement weapon trigger lock/unlock
			
			// _prevFrameIsLockOnTarget = isLockedOnTargetNow;
		}

		// TODO: Implement IEnemyTarget
		// private void SmoothLookOnTarget()
		// {
		// 	var direction = (_target.CurrentPosition - transform.position).normalized;
		// 	var targetRotation = Quaternion.LookRotation(direction);
		// 	transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
		// }
		
		// private bool GetIsLockedOnTargetNow()
		// {
		// 	var direction = (_target.CurrentPosition - transform.position).normalized;
		// 	var targetRotation = Quaternion.LookRotation(direction);
		// 	return Quaternion.Angle(transform.rotation, targetRotation) <= _lockAnglePrecision;
		// }
		
		#endregion
	}
}