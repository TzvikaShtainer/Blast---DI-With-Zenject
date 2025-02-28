using Blast.DataTypes;
using Blast.ServiceLayer.GameScenes;
using Blast.VisualLayer.Loader;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Blast.VisualLayer.SelectLevel.Handlers
{
    public class EnterLevelHandler : IEnterLevelHandler
    {
        [Inject] 
        private ILoader _loader;
        
        [Inject]
        private IGameScenesService scenesService;
        
        public async void Execute(GameLevelType levelType)
        {
            _loader.ResetData();
            await _loader.FadeIn();
            await UniTask.Delay(500);
            _loader.SetProgress(0.2f, "Loading Level 20%");

            await scenesService.UnloadInfraScreen(InfraScreenType.SelectLevel);
                
            await UniTask.Delay(1000);
            _loader.SetProgress(0.5f, "Loading Level 50%");

            await scenesService.LoadLevelSceneIfNotLoaded(levelType);
            await UniTask.Delay(500);
            _loader.SetProgress(1f, "Loading Level 100%");
            
            _loader.FadeOut();

        }
    }
}