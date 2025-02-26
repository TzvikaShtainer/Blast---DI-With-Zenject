using Blast.DataTypes;
using Blast.VisualLayer.Cannons.Components;
using Blast.VisualLayer.CannonStudio.Handlers;
using Blast.VisualLayer.CannonStudio.Installers;
using Blast.VisualLayer.Factories;
using Blast.VisualLayer.Gameplay.Handlers;
using Blast.VisualLayer.Gameplay.PlayerInput;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Gameplay.Installers
{
    public class GamePlayInstaller : MonoInstaller<GamePlayInstaller>
    {
        [SerializeField]
        private Transform _cannonParentTrasform;

        [SerializeField]
        private PlayerCannonType _cannonToPlayWith;

        [SerializeField] 
        private GameLevelType _levelType;
        
        public override void InstallBindings()
        {
            Container
                .Bind<IPlayerInput>()
                .To<DesktopInputManager>()
                .AsSingle()
                .IfNotBound();
            
            Container
                .Bind<Transform>()
                .FromInstance(_cannonParentTrasform)
                .AsSingle();
            
            Container
                .Bind<IHudBackClickHandler>()
                .To<HudBackButtonHandler>()
                .AsSingle();
            
            Container
                .Bind<GameLevelType>()
                .FromInstance(_levelType)
                .AsSingle();

            Container
                .Bind<IInitializable>()
                .To<GamePlayLevelEntryPoint>()
                .AsSingle();

            Container
                .BindFactory<PlayerCannonType, Transform, IEnemyTarget, CannonFactory>() //signature, Factory
                .FromFactory<CannonFactoryImplementation>();
        }
    }
}