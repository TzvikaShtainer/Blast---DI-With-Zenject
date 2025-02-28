using Blast.DataLayer;
using Blast.VisualLayer.SelectLevel.Components;
using Zenject;

namespace Blast.VisualLayer.SelectLevel.Handlers
{
    public class SelectLevelScreenEntryPoint : IInitializable
    {
        [Inject]
        private IDataLayer _dataLayer;
        
        [Inject]
        private EnterLevelButton.Factory _enterLevelButtonFactory;
        
        public void Initialize()
        {
            var existingLevels = _dataLayer.Metadata.GetLevelsMetadata();

            foreach (var gameLevelMetadata in existingLevels)
            {
               //create enter level button 
               _enterLevelButtonFactory.Create(gameLevelMetadata);
            }
        }
    }
}