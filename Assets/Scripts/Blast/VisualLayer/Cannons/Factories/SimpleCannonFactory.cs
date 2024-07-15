using System;
using Blast.VisualLayer.Cannons.Components;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Blast.VisualLayer.Cannons.Factories
{
    public class SimpleCannonFactory : IFactory<Transform, PlayerCannon>
    {

        [Inject]
        private DiContainer _container;

        [Inject] 
        private Object _cannonPrefabRef;
        
        
        public PlayerCannon Create(Transform parentTransform)
        {
            var prefabInstance =_container.InstantiatePrefab(_cannonPrefabRef);
            return prefabInstance.GetComponent<PlayerCannon>();
        }
    }
}