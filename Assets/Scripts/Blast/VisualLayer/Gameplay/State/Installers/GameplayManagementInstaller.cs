using Blast.VisualLayer.Gameplay.Handlers;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Gameplay.State.Installers
{
    [CreateAssetMenu(menuName = "Blast/State/Signal Based State Management Installer", fileName = "State Management Installer")]
    public class GameplayManagementInstaller : ScriptableObjectInstaller<GameplayManagementInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<GameEndHandler>()
                .AsTransient();
            
            Container
                .BindInterfacesTo<SignalBasedStateManager>()
                .AsSingle();
        }
    }
}