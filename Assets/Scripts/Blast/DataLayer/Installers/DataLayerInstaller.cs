using Blast.DataLayer.Metadata;
using Blast.DataTypes;
using UnityEngine;
using Zenject;

namespace Blast.DataLayer.Installers
{
    [CreateAssetMenu(menuName = "Blast/Data/Data Layer Installer", fileName = "Data Layer Installer")]
    public class DataLayerInstaller : ScriptableObjectInstaller<DataLayerInstaller>
    {
        [SerializeField] private CannonMetadata[] _cannonMetadatas;
        
        public override void InstallBindings()
        {
            Container
                .Bind<IDataLayer>()
                .To<DataLayer>()
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