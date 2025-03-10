using System;
using Blast.DataTypes;
using Blast.ServiceLayer.GameScenes;
using Blast.ServiceLayer.TimeControl;
using Blast.VisualLayer.Loader;
using Blast.VisualLayer.Popups.YesNo;
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
        
        [Inject]
        private YesNoPopup.Factory _yesNoPopupFactory;
        
        [Inject]
        private ITimeController _timeController;
        
        public async UniTask Execute()
        {
            _timeController.PauseGameplay();
            
            var popup = _yesNoPopupFactory.Create(YesNoPopupArgs.Default);
            var result = await popup.WaitForResult();
            
            _timeController.UnpauseGameplay();
            
            if (result.IsNo)
            {
                return;
            }
            
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