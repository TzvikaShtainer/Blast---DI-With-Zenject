using Blast.DataTypes;
using Cysharp.Threading.Tasks;

namespace Blast.ServiceLayer.GameScenes
{
    public class GameScenesService : IGameScenesService
    {
        #region Injects

        #endregion
        
        #region Methods

        public async UniTask LoadInfraSceneIfNotLoaded(InfraScreenType sceneType)
        {
            if (IsInfraSceneLoaded(sceneType))
            {
                return;
            }
        }

        public async UniTask LoadLevelSceneIfNotLoaded(GameLevelType levelType)
        {
            if (IsLevelSceneLoaded(levelType))
            {
                return;
            }
        } 
        
        public async UniTask UnloadInfraScreen(InfraScreenType sceneType)
        {
        }

        public async UniTask UnloadLevelScene(GameLevelType levelType)
        {
        }

        private bool IsLevelSceneLoaded(GameLevelType levelType)
        {
            try
            {
            }
            catch
            {
                // ignored
            }

            return false;
        }

        private bool IsInfraSceneLoaded(InfraScreenType sceneType)
        {
            try
            {
            }
            catch
            {
                // ignored
            }

            return false;
        }

        #endregion
    }
}