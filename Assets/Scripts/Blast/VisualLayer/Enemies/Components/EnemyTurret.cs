using Blast.ServiceLayer.Signals.Payloads;
using Blast.VisualLayer.Cannons.Components;
using Blast.VisualLayer.Components;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Enemies.Components
{
	// TODO: Add [RequireComponent]
	public class EnemyTurret : MonoBehaviour
	{
		#region Factories

		public class Factory : PlaceholderFactory<IEnemyTarget, EnemyTurret>
		{
		}
		
		#endregion
		
		#region Editor

		[SerializeField]
		[Range(1, 100)]
		private float _rotationSpeed;

		[SerializeField]
		private float _lockAnglePrecision = 5;
		
		 //[SerializeField]
		 //private AutomaticWeaponTrigger _weaponTrigger;
		
		#endregion
		
		#region Fields

		private Damageable _damageable;
		
		private bool _prevFrameIsLockOnTarget;

		private IEnemyTarget _target;
		
		#endregion

		#region Injects

		[Inject]
		private SignalBus _signalBus;
		

		#endregion
		
		#region Methods

		[Inject]
		public void Construct(IEnemyTarget target)
		{
			_target = target;
			_signalBus.Subscribe<GameEnd>(OnGameEnd);
		}
		
		private void OnGameEnd()
		{
			//_weaponTrigger.enabled = false;
			enabled = false;
		}

		private void Awake()
		{
			_damageable = GetComponent<Damageable>();
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
			
			_signalBus.Unsubscribe<GameEnd>(OnGameEnd);
		}

		private void OnDamageReceived(int receivedDamage)
		{
			_signalBus.Fire<EnemyTurretHit>();
		}

		private void OnDestroyed()
		{
			_signalBus.Fire<EnemyTurretDestroyed>();
		}

		private void Update()
		{
			HandleLookOnTarget();
		}

		private void HandleLookOnTarget()
		{
			SmoothLookOnTarget();
			var isLockedOnTargetNow = GetIsLockedOnTargetNow();
			_prevFrameIsLockOnTarget = isLockedOnTargetNow;
		}
		
		 private void SmoothLookOnTarget()
		 {
		 	var direction = (_target.CurrentPosition - transform.position).normalized;
		 	var targetRotation = Quaternion.LookRotation(direction);
		 	transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
		 }
		
		 private bool GetIsLockedOnTargetNow()
		 {
		 	var direction = (_target.CurrentPosition - transform.position).normalized;
		 	var targetRotation = Quaternion.LookRotation(direction);
		 	return Quaternion.Angle(transform.rotation, targetRotation) <= _lockAnglePrecision;
		 }
		
		#endregion
	}
}