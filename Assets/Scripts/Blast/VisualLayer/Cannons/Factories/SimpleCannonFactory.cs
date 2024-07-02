using Blast.VisualLayer.Cannons.Components;
using Zenject;

namespace Blast.VisualLayer.Cannons.Factories
{
    public class SimpleCannonFactory : IFactory<PlayerCannon>
    {

        [Inject]
        private DiContainer _container;
        public PlayerCannon Create()
        {
            var prefabInstance =_container.InstantiatePrefab(null);
            return prefabInstance.GetComponent<PlayerCannon>();
        }
    }
}