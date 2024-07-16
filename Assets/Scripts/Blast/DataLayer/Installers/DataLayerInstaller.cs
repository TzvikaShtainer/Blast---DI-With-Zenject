using UnityEngine;
using Zenject;

namespace Blast.DataLayer.Installers
{
    [CreateAssetMenu(menuName = "Blast/Data/Data Layer Installer", fileName = "Data Layer Installer")]
    public class DataLayerInstaller : ScriptableObjectInstaller<DataLayerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IDataLayer>()
                .To<DataLayer>()
                .AsSingle();
        }
    }
}