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
		#endregion
		
		#region Methods

		private void Update()
		{
		}

		private void Fire()
		{
		}

		#endregion
	}
}