using Blast.DataTypes;
using Blast.ServiceLayer.GameScenes;
using Blast.ServiceLayer.TimeControl;
using Blast.VisualLayer.Loader;
using Blast.VisualLayer.Popups.YesNo;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Blast.VisualLayer.Gameplay.Handlers
{
    public class GameEndHandler
    {
        [Inject]
        private ITimeController _timeController;
        
        [Inject]
        private YesNoPopup.Factory _yesNoPopupFactory;
        
        [Inject]
        private ILoader _loader;
        
        [Inject]
        private IGameScenesService _scenesService;

        [Inject]
        private GameLevelType _currentLevelType;
        
        public async void Execute(bool isPlayerWin)
        {
            _timeController.PauseGameplay();

            var popupArgs = new YesNoPopupArgs
            {
                Text = isPlayerWin ? "You won!" : "You lose!",
                IsNoButtonVisible = false,
                YesCaption = isPlayerWin ? "Great!" : "=("
            };

            var popupResult = await _yesNoPopupFactory.Create(popupArgs).WaitForResult();
            
            _timeController.UnpauseGameplay();
            
            _loader.ResetData();
            await _loader.FadeIn();
            _loader.SetProgress(0.1f, "Going Back");
            await UniTask.Delay(1500);
            _loader.SetProgress(0.5f, "Unloading The Level");
            
            //unload gameplay lvl scene
            await _scenesService.UnloadLevelScene(_currentLevelType);
            
            //load lvl selection scene
            await _scenesService.LoadInfraSceneIfNotLoaded(InfraScreenType.SelectLevel);
            
            
            await UniTask.Delay(1500);
            await _loader.FadeOut();
        }
    }
}