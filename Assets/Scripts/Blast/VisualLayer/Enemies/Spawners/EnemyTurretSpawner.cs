using System.Collections.Generic;
using Blast.Extensions;
using Blast.ServiceLayer.Signals.Payloads;
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
		
		#endregion
		
		private EnemyTurret _currentTurret;
		

		#region Methods

		public void BeginSpawning()
		{
			_currentTurret = _factory.Create();
		}

		public void StopSpawning()
		{
		}

		#endregion
	}
}