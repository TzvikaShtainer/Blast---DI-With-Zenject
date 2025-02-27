using Blast.DataLayer.Balances;
using Blast.DataLayer.Metadata;
using Blast.DataTypes;
using UnityEngine;
using Zenject;

namespace Blast.DataLayer.Installers
{
    [CreateAssetMenu(menuName = "Blast/Data/Data Layer Installer", fileName = "Data Layer Installer")]
    public class DataLayerInstaller : ScriptableObjectInstaller<DataLayerInstaller>
    {
        [SerializeField] 
        private CannonMetadata[] _cannonMetadatas;
        
        [SerializeField]
        private GameLevelMetadata[] _levelsMetadata;
        
        [SerializeField]
        private InfraScreenMetadata[] _infraScreenMetadatas;

        [SerializeField] 
        private PlayerBalances _playerBalances;
        
        public override void InstallBindings()
        {
            Container
                .Bind<IDataLayer>()
                .FromSubContainerResolve()
                .ByMethod(SubContainerBindings)
                .AsSingle();
        }

        private void SubContainerBindings(DiContainer subContainer)
        {
            subContainer
                .Bind<IDataLayer>()
                .To<DataLayer>()
                .AsSingle();
            
            subContainer
                .Bind<IPlayerBalances>()
                .To<PlayerBalances>()
                .FromInstance(_playerBalances )
                .AsSingle();

            subContainer
                .Bind<IGameMetadata>()
                .To<GameMetadata>()
                .AsSingle();

            subContainer
                .Bind<CannonMetadata[]>()
                .FromInstance(_cannonMetadatas)
                .AsSingle();

            subContainer
                .Bind<GameLevelMetadata[]>()
                .FromInstance(_levelsMetadata)
                .AsCached();
            
            subContainer
                .Bind<InfraScreenMetadata[]>()
                .FromInstance(_infraScreenMetadatas)
                .AsCached();
        }
    }
}