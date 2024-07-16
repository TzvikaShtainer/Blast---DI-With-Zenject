using Blast.DataTypes;
using Blast.ServiceLayer.Signals.Payloads;
using Blast.VisualLayer.Cannons.Components;
using Blast.VisualLayer.Cannons.Factories;
using Blast.VisualLayer.CannonStudio.Handlers;
using Blast.VisualLayer.Factories;
using Blast.VisualLayer.Gameplay.Handlers;
using Blast.VisualLayer.Gameplay.PlayerInput;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.CannonStudio.Installers
{
    public class CannonStudioInstaller : MonoInstaller<CannonStudioInstaller>
    {
        [SerializeField]
        private Transform _cannonParentTrasform;

        [SerializeField]
        private PlayerCannonType _cannonToPlayWith;
        
        public override void InstallBindings()
        {
            Container
                .Bind<IPlayerInput>()
                .To<DesktopInputManager>()
                .AsSingle()
                .IfNotBound();

            Container
                .Bind<PlayerCannonType>()
                .FromInstance(_cannonToPlayWith)
                .AsSingle();
            
            Container
                .Bind<Transform>()
                .FromInstance(_cannonParentTrasform)
                .AsSingle();
            
            Container
                .Bind<IHudBackClickHandler>()
                .To<MockBackClickHandler>()
                .AsSingle();

            Container
                .Bind<IInitializable>()
                .To<CannonStudioEntryPoint>()
                .AsSingle();

            Container
                .BindFactory<PlayerCannonType, Transform, GameObject, CannonFactory>()
                .FromFactory<CannonFactoryImplementation>();


        }
    }
}