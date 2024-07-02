using Blast.VisualLayer.CannonStudio.Handlers;
using Blast.VisualLayer.Gameplay.Handlers;
using Blast.VisualLayer.Gameplay.PlayerInput;
using Zenject;

namespace Blast.VisualLayer.CannonStudio.Installers
{
    public class CannonStudioInstaller : MonoInstaller<CannonStudioInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IPlayerInput>()
                .To<DesktopInputManager>()
                .AsSingle()
                .IfNotBound();

            Container
                .Bind<IHudBackClickHandler>()
                .To<MockBackClickHandler>()
                .AsSingle();
        }
    }
}