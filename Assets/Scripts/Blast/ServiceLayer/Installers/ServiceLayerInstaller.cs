﻿using Blast.ServiceLayer.GameScenes;
using Blast.ServiceLayer.TimeControl;
using UnityEngine;
using Zenject;

namespace Blast.ServiceLayer
{
    [CreateAssetMenu(menuName = "Blast/Data/Service Layer Installer", fileName = "Service Layer Installer")]
    public class ServiceLayerInstaller : ScriptableObjectInstaller<ServiceLayerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IGameScenesService>()
                .To<GameScenesService>()
                .AsSingle();
            
            Container
                .Bind<ITimeController>()
                .To<TimeController>()
                .AsSingle();
        }
    }
}