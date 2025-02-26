using Blast.VisualLayer.Loader;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Blast.VisualLayer.Gameplay.Handlers
{
    public class HudBackButtonHandler : IHudBackClickHandler
    {
        [Inject]
        private ILoader _loader;
        public async UniTask Execute()
        {
            _loader.ResetData();
            await _loader.FadeIn();
            _loader.SetProgress(0.1f, "Loader Testing");
            await UniTask.Delay(1500);
            _loader.SetProgress(0.2f, "Loader Testing 20%");
            await UniTask.Delay(1500);
            _loader.SetProgress(0.5f, "Loader Testing 50%");
            await UniTask.Delay(1500);
            _loader.SetProgress(1f, "Loader Testing 100%");
            await UniTask.Delay(1500);
            await _loader.FadeOut();
        }
    }
}