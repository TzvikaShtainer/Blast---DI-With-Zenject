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
        private PlayerBalances _playerBalances;
        
        public override void InstallBindings()
        {
            Container
                .Bind<IDataLayer>()
                .To<DataLayer>()
                .AsSingle();

            Container
                .Bind<IPlayerBalances>()
                .To<PlayerBalances>()
                .FromInstance(_playerBalances)
                .AsSingle();

            Container
                .Bind<IGameMetadata>()
                .To<GameMetadata>()
                .AsSingle();

            Container
                .Bind<CannonMetadata[]>()
                .FromInstance(_cannonMetadatas)
                .AsSingle();
        }
    }
}