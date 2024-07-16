using Blast.ServiceLayer.Signals.Payloads;
using Blast.VisualLayer.Cannons.Components;
using Blast.VisualLayer.Cannons.Factories;
using Blast.VisualLayer.CannonStudio.Handlers;
using Blast.VisualLayer.Gameplay.Handlers;
using Blast.VisualLayer.Gameplay.PlayerInput;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.CannonStudio.Installers
{
    public class CannonStudioInstaller : MonoInstaller<CannonStudioInstaller>
    {
        [SerializeField]
        private Object _currentCannonPrefab;
        
        [SerializeField]
        private Transform _cannonParentTrasform;
        
        public override void InstallBindings()
        {
            Container
                .Bind<IPlayerInput>()
                .To<DesktopInputManager>()
                .AsSingle()
                .IfNotBound();

            Container
                .Bind<IHudBackClickHandler>()
                .To<MockBackClickHandler>()
                .AsSingle();

            Container
                .Bind<IInitializable>()
                .To<CannonStudioStartHandler>()
                .AsSingle();
            
            Container
                .Bind<Object>()
                .FromInstance(_currentCannonPrefab)
                .AsSingle();
            
            Container
                .Bind<Transform>()
                .FromInstance(_cannonParentTrasform)
                .AsSingle();
            
            Container
                .BindFactory<PlayerCannon, PlayerCannon.Factory>()
                .FromComponentInNewPrefab(_currentCannonPrefab)
                .UnderTransform(_cannonParentTrasform)
                .AsSingle();
        }
    }
}