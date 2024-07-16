using Blast.DataTypes;
using Blast.VisualLayer.Cannons.Components;
using Blast.VisualLayer.Factories;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.CannonStudio.Installers
{
    public class CannonStudioEntryPoint : IInitializable
    {
        [Inject] 
        private CannonFactory _cannonFactory;
        public void Initialize()
        {
            var cannonInstance = _cannonFactory.Create(PlayerCannonType.Bullet, null);
        }
    }
}