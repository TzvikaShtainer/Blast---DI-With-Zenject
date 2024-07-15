using Blast.VisualLayer.Cannons.Components;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.CannonStudio.Installers
{
    public class CannonStudioStartHandler : IInitializable
    {

        [Inject]
        private IFactory<Transform, PlayerCannon> _playerCannon;

        [Inject]
        private Transform _cannonParentParam;
        public void Initialize()
        {
            var playerCannon = _playerCannon.Create(_cannonParentParam);
        }
    }
}