using Blast.VisualLayer.Gameplay.PlayerInput;
using Blast.VisualLayer.Weapons.Logic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Zenject;

namespace Blast.VisualLayer.Components
{
	public class InputDrivenWeaponTrigger : MonoBehaviour
	{
		#region Editor
		
		public UnityEvent OnFire;
		
		#endregion

		#region Injects
		
		[InjectOptional]
		private IPlayerInput _playerInput;

		[Inject]
		private IWeaponLogic _weaponLogic;
		
		#endregion
		
		#region Methods

		private void Update()
		{
			if (_playerInput == null)
			{
				return;
			}

			if (_playerInput.IsFireRequested)
			{
				Fire();
			}
		}

		private void Fire()
		{
			_weaponLogic.Fire();
			OnFire?.Invoke();
		}

		#endregion
	}
}