using Blast.VisualLayer.Gameplay.PlayerInput;
using Blast.VisualLayer.Weapons.Logic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Blast.VisualLayer.Components
{
	public class InputDrivenWeaponTrigger : MonoBehaviour
	{
		#region Editor

		[SerializeField]
		private UnityEvent _onFire;

		[SerializeField]
		private Transform[] _launchingPoints;
		
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
			_weaponLogic.Fire(_launchingPoints);
		}

		#endregion
	}
}