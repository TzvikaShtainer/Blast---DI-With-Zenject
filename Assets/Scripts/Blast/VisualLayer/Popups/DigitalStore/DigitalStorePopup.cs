using Cysharp.Threading.Tasks;
using Zenject;

namespace Blast.VisualLayer.Popups.DigitalStore
{
    public class DigitalStorePopup : Popup
    {
        #region Factories

        #endregion
        
        #region Fields
        #endregion
        
        #region Methods

        public UniTask<DigitalStorePopupResult> WaitForResult()
        {
            return default;
        }

        public void OnPurchaseCurrencyPackButtonClick(CurrencyPackData currencyPackData)
        {
            Close();
        }

        public void OnCloseButtonClick()
        {
            Close();
        }

        #endregion
    }
}