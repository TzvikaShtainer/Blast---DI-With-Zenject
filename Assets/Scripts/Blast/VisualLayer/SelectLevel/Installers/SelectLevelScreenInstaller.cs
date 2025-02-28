using Blast.DataTypes;
using Blast.VisualLayer.SelectLevel.Components;
using Blast.VisualLayer.SelectLevel.Handlers;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.SelectLevel.Installers
{
    public class SelectLevelScreenInstaller : MonoInstaller<SelectLevelScreenInstaller>
    {
        [SerializeField]
        EnterLevelButton _enterLevelButtonPrefabRef;

        [SerializeField]
        private RectTransform _enterLevelButtonParentTranform;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<SelectLevelScreenEntryPoint>() // Binds all interfaces implemented by SelectLevelScreenEntryPoint
                .AsSingle()
                .NonLazy(); //method ensures that the bound dependency is instantiated immediately when the container initializes, rather than waiting until it is first resolved.

            Container
                .BindFactory<GameLevelMetadata, EnterLevelButton,
                    EnterLevelButton.Factory>() //what i need, return, factory
                .FromComponentInNewPrefab(_enterLevelButtonPrefabRef)
                .UnderTransform(_enterLevelButtonParentTranform)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<EnterLevelHandler>()//bind direct to the class
                .AsSingle();
        }
    }
}