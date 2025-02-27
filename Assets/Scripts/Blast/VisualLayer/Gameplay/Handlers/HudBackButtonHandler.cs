using Blast.DataTypes;
using Blast.ServiceLayer.GameScenes;
using Blast.VisualLayer.Loader;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Blast.VisualLayer.Gameplay.Handlers
{
    public class HudBackButtonHandler : IHudBackClickHandler
    {
        [Inject]
        private ILoader _loader;
        
        [Inject]
        private IGameScenesService _scenesService;
        
        [Inject]
        private GameLevelType _currentLevelType;
        
        public async UniTask Execute()
        {
            _loader.ResetData();
            await _loader.FadeIn();
            _loader.SetProgress(0.1f, "Loader");
            await UniTask.Delay(1500);
            _loader.SetProgress(0.2f, "Loader 20%");
            await UniTask.Delay(1500);
            _loader.SetProgress(0.5f, "Loader 50%");
            
            //unload gameplay lvl scene
            await _scenesService.UnloadLevelScene(_currentLevelType);
            
            await UniTask.Delay(1500);
            _loader.SetProgress(1f, "Loader 100%");
            
            //load lvl selection scene
            await _scenesService.LoadInfraSceneIfNotLoaded(InfraScreenType.SelectLevel);
            
            
            await UniTask.Delay(1500);
            await _loader.FadeOut();
        }
    }
}