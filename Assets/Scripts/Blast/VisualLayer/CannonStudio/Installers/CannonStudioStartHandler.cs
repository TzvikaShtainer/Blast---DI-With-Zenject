using Blast.VisualLayer.Cannons.Components;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.CannonStudio.Installers
{
    public class CannonStudioStartHandler : IInitializable
    {
        [Inject]
        private PlayerCannon.Factory _factory;
        public void Initialize()
        {
           var cannon = _factory.Create();
        }
    }
}