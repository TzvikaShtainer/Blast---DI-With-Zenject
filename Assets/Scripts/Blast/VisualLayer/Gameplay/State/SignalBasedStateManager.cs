using Blast.DataTypes;
using Blast.ServiceLayer.Signals.Payloads;
using Blast.VisualLayer.Gameplay.Handlers;
using Zenject;

namespace Blast.VisualLayer.Gameplay.State
{
	public class SignalBasedStateManager : IInitializable
	{
		#region Injects
		
		[Inject]
		private SignalBus _signalBus;
		
		#endregion

		private int _enemiesRemains = 0;
		
		#region Methods

		public void Initialize()
		{
			_signalBus.Subscribe<EnemyTurretSpawned>(OnEnemySpawned);
			_signalBus.Subscribe<EnemyTurretDestroyed>(OnEnemyDestroyed);
			_signalBus.Subscribe<PlayerCannonDestroyed>(OnPlayerDestroyed);
		}

		private void OnEnemySpawned()
		{
			_enemiesRemains++;
		}

		private async void OnEnemyDestroyed()
		{
			_enemiesRemains--;
			if (_enemiesRemains <= 0)
			{
				// TODO: Execute GameEndHandler, player win
			}
		}

		private async void OnPlayerDestroyed()
		{
			// TODO: Execute GameEndHandler, player loose
		}

		#endregion
	}
}