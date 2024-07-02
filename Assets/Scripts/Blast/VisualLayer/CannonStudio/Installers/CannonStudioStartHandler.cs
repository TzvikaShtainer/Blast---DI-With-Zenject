using Blast.VisualLayer.Cannons.Components;
using Zenject;

namespace Blast.VisualLayer.CannonStudio.Installers
{
    public class CannonStudioStartHandler : IInitializable
    {

        [Inject]
        private IFactory<PlayerCannon> _playerCannon;
        public void Initialize()
        {
            var playerCannonInstance = _playerCannon.Create();
        }
    }
}