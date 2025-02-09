using System.Collections.Generic;
using Blast.DataTypes;
using Blast.VisualLayer.Cannons.Components;
using Blast.VisualLayer.Enemies.Spawners;
using Blast.VisualLayer.Factories;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.CannonStudio.Installers
{
    public class CannonStudioEntryPoint : IInitializable
    {
        [Inject] 
        private CannonFactory _cannonFactory;

        [Inject] 
        private Transform _cannonParent;
          
        [Inject] 
        private PlayerCannonType _canonToPlay;

        [Inject]  
        private List<IEnemySpawner> _enemySpawners;
        
        public void Initialize()
        {
            var cannonInstance = _cannonFactory.Create(_canonToPlay, _cannonParent);

            foreach (var enemySpawner in _enemySpawners)
            {
                enemySpawner.BeginSpawning(cannonInstance);
            }
        }
    }
}