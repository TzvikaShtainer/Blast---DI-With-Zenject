using Blast.VisualLayer.Popups.DigitalStore;
using Zenject;

namespace Blast.VisualLayer.SelectLevel.Handlers
{
    public class HudPlusCurrencyButtonClickHandler : IHudPlusCurrencyClickHandler
    {
        [Inject]
        private DigitalStorePopup.Factory _storePopupFactory;
        public void Execute()
        {
            var popup = _storePopupFactory.Create();
        }
    }
}