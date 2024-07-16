using Blast.DataLayer;
using Blast.DataTypes;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Factories
{
    //first factory - what we will inject everywhere
    public class CannonFactory : PlaceholderFactory<PlayerCannonType, Transform, GameObject>
    {
        
    }

    
    //second factory - the Implementation
    public class CannonFactoryImplementation : IFactory<PlayerCannonType, Transform, GameObject>
    {
        [Inject] 
        private IDataLayer _dataLayer;

        [Inject]
        private DiContainer _container;
        public GameObject Create(PlayerCannonType param1, Transform param2)
        {
             var cannonPrefab = _dataLayer.Metadata.GetPrefabForCannon(param1);
            return _container.InstantiatePrefab(cannonPrefab, param2);
        }
    }
}