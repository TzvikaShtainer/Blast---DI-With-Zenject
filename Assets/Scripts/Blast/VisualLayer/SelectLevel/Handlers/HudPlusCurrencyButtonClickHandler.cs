using Blast.DataLayer;
using Blast.VisualLayer.Popups.DigitalStore;
using Zenject;

namespace Blast.VisualLayer.SelectLevel.Handlers
{
    public class HudPlusCurrencyButtonClickHandler : IHudPlusCurrencyClickHandler
    {
        [Inject]
        private DigitalStorePopup.Factory _storePopupFactory;
        
        [Inject]
        private IDataLayer _dataLayer;
        
        public async void Execute()
        {
            //במשחק אמיתי פה נממש את השירות שיוצר קשר עם החנות של גוגל ונבדוק לגבי הרכישה
            var popup = _storePopupFactory.Create();
            var popupInteractionResult = await popup.WaitForResult();

            if (popupInteractionResult.IsCanceled)
            {
                return;
            }
            
            _dataLayer.Balances.AddCurrency(
                popupInteractionResult.SelectedPack.CurrencyType, 
                popupInteractionResult.SelectedPack.AdditionAmount);
        }
    }
}