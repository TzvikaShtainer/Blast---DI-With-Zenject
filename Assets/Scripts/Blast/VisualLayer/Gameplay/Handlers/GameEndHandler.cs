using System;
using Blast.DataTypes;
using Blast.ServiceLayer.GameScenes;
using Blast.ServiceLayer.Signals.Payloads;
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
        
        [Inject]
        private SignalBus _signalBus;
        
        public async void Execute(bool isPlayerWin)
        {
            _signalBus.Fire<GameEnd>();
            
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
            _loader.SetProgress(0.1f, "Going to the level selection");
            await UniTask.Delay(TimeSpan.FromSeconds(1));

            
            //unload gameplay lvl scene
            _loader.SetProgress(0.2f, "Unloading the level");
            await _scenesService.UnloadLevelScene(_currentLevelType);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            
            //load lvl selection scene
            _loader.SetProgress(0.4f, "Loading levels list");
            await _scenesService.LoadInfraSceneIfNotLoaded(InfraScreenType.SelectLevel);
            
            await _scenesService.LoadInfraSceneIfNotLoaded(InfraScreenType.Loader);
            await _scenesService.LoadInfraSceneIfNotLoaded(InfraScreenType.GamePopups);
            
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            _loader.SetProgress(0.9f, "Completing");
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            await _loader.FadeOut();
        }
    }
}