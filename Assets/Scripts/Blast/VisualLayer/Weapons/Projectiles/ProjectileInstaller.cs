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

        [SerializeField] 
        [Range(10, 100)] 
        private int _initialPoolSize = 20;
        
        [SerializeField] 
        [Range(10, 100)] 
        private int _maxPoolSize = 40;
        
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
                .FromPoolableMemoryPool(
                    poolInitializer => poolInitializer
                        .WithInitialSize(_initialPoolSize)
                        .WithMaxSize(_maxPoolSize)
                        .FromComponentInNewPrefab(_projectilePrefabRef)
                        .UnderTransformGroup("Projectiles Pool"));

        }
    }
}