using Blast.VisualLayer.Enemies.Components;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Enemies.Installers
{
    public class EnemyTurretFactoryInstaller : MonoInstaller<EnemyTurretFactoryInstaller>
    {
        [SerializeField]
        private GameObject _turretPrefabRef;
        
        [SerializeField]
        private Transform _parentTransform;
        
        public override void InstallBindings()
        {
            Container
                .BindFactory<EnemyTurret, EnemyTurret.Factory>()
                .FromComponentInNewPrefab(_turretPrefabRef) // Create a new game object at the root of the scene using the given prefab
                                                            // After zenject creates a new GameObject from the given prefab, it will
                                                            // search the prefab for a component of type 'Foo' and return that
                .UnderTransform(_parentTransform)
                .AsTransient();  // Create a new instance of Foo for every class that asks for it
        }
    }
}