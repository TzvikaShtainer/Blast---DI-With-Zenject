using System.Collections.Generic;
using Blast.Extensions;
using Blast.ServiceLayer.Signals.Payloads;
using Blast.VisualLayer.Cannons.Components;
using Blast.VisualLayer.Enemies.Components;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Enemies.Spawners
{
	public class EnemyTurretSpawner : MonoBehaviour, IEnemySpawner
	{
		#region Injects

		[Inject]
		private EnemyTurret.Factory _factory;
		
		[Inject]
		private SignalBus _signalBus;
		
		#endregion
		
		private EnemyTurret _currentTurret;
		

		#region Methods

		public void BeginSpawning(IEnemyTarget target)
		{
			_currentTurret = _factory.Create(target);
			
			_signalBus.Fire<EnemyTurretSpawned>();
		}

		public void StopSpawning()
		{
		}

		#endregion
	}
}