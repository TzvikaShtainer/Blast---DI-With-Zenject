using System.Collections.Generic;
using Blast.DataLayer;
using Blast.DataTypes;
using Blast.VisualLayer.Enemies.Spawners;
using Blast.VisualLayer.Factories;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Gameplay.Handlers
{
    public class GamePlayLevelEntryPoint : IInitializable
    {
        [Inject]
        private CannonFactory _cannonFactory;
        
        [Inject]
        private Transform _cannonParentTransform;
        
        [Inject]
        private IDataLayer _dataLayer;
        
        [Inject]
        GameLevelType _levelType;
        
        [Inject]
        private List<IEnemySpawner> _enemySpawners; 
        public void Initialize()
        {
            var levelMetadata = _dataLayer.Metadata.GetLevelMetadata(_levelType);
            var cannonInstance = _cannonFactory.Create(levelMetadata.CannonType, _cannonParentTransform);

            foreach (var enemySpawner in _enemySpawners)
            {
                enemySpawner.BeginSpawning(cannonInstance);
            }
        }
    }
}