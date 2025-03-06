using Blast.DataLayer;
using Blast.DataTypes;
using Blast.ServiceLayer.GameScenes;
using Blast.VisualLayer.Loader;
using Blast.VisualLayer.Popups.SelectCannon;
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
        
        [Inject]
        private SelectCannonPopup.Factory _selectCannonPopup;
        
        [Inject]
        private IDataLayer _dataLayer;
        
        public async void Execute(GameLevelType levelType)
        {
            var popup = _selectCannonPopup.Create();
            var result = await popup.WaitForResult();
            if (result.IsCanceled)
            {
                return;
            }

            var selectedCannon = result.SelectedCannonType;
            var levelMetadata = _dataLayer.Metadata.GetLevelMetadata(levelType);
            levelMetadata.SetCannon(selectedCannon);
            
            
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