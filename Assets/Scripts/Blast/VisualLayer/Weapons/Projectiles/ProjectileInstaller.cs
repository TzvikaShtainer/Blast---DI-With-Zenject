using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Weapons.Projectiles
{
    [CreateAssetMenu(menuName = "Blast/Weapons/ProjectileInstaller", fileName = "ProjectileInstaller")]
    public class ProjectileInstaller : ScriptableObjectInstaller<ProjectileInstaller>
    {
        [SerializeField]
        private GameObject _projectilePrefabRef;
        
        [SerializeField]
        private GameObject _muzzleFlashVfxPrefabRef;
        
        [SerializeField]
        private GameObject _collisionVfxPrefabRef;
        
        public override void InstallBindings()
        {
            Container
                .Bind<GameObject>()
                .WithId(WeaponsBindingIds.MuzzleFlashVfxPrefabRef)
                .FromInstance(_muzzleFlashVfxPrefabRef)
                .AsTransient();
            
            Container
                .Bind<GameObject>()
                .WithId(WeaponsBindingIds.CollisionVfxPrefabRef)
                .FromInstance(_collisionVfxPrefabRef)
                .AsTransient();
            
            Container
                .BindFactory<Vector3, Vector3, Projectile, Projectile.Factory>()
                .FromComponentInNewPrefab(_projectilePrefabRef) // Create a new game object at the root of the scene using the given prefab
                                                                // After zenject creates a new GameObject from the given prefab, it will
                                                                // search the prefab for a component of type 'Foo' and return that
                .AsSingle();
        }
    }
}