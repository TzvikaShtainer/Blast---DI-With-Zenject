using Blast.DataLayer;
using Blast.DataTypes;
using Blast.VisualLayer.Cannons.Components;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Factories
{
    //first factory - what we will inject everywhere
    public class CannonFactory : PlaceholderFactory<PlayerCannonType, Transform, IEnemyTarget>
    {
        
    }

    
    //second factory - the Implementation
    public class CannonFactoryImplementation : IFactory<PlayerCannonType, Transform, IEnemyTarget>
    {
        [Inject] 
        private IDataLayer _dataLayer;

        [Inject]
        private DiContainer _container;
        public IEnemyTarget Create(PlayerCannonType param1, Transform param2)
        {
            var cannonPrefab = _dataLayer.Metadata.GetPrefabForCannon(param1);
            var cannonInstance = _container.InstantiatePrefab(cannonPrefab, param2);
            return cannonInstance.GetComponent<IEnemyTarget>();
        }
    }
}