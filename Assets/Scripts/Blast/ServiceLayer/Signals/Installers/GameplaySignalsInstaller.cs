using Blast.ServiceLayer.Signals.Payloads;
using UnityEngine;
using Zenject;

namespace Blast.ServiceLayer.Signals.Installers
{
    [CreateAssetMenu(menuName = "Blast/Signals/Gameplay Signals", fileName = "Gameplay Signals")]
    public class GameplaySignalsInstaller : ScriptableObjectInstaller<GameplaySignalsInstaller>
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.DeclareSignal<PlayerCannonFired>();
            Container.DeclareSignal<EnemyTurretDestroyed>();
            Container.DeclareSignal<EnemyTurretFired>();
            Container.DeclareSignal<EnemyTurretHit>();
            Container.DeclareSignal<EnemyTurretSpawned>();
            Container.DeclareSignal<PlayerCannonDestroyed>();
        }
    }
}