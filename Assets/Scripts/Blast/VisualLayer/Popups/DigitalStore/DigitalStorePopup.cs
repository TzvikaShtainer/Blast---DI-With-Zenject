using System;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Blast.VisualLayer.Popups.DigitalStore
{
    public class DigitalStorePopup : Popup
    {
        #region Factories

        public class Factory : PlaceholderFactory<DigitalStorePopup>
        {
            
        }
        #endregion
        
        #region Fields

        private UniTaskCompletionSource<DigitalStorePopupResult> _tcs;
        
        #endregion
        
        #region Methods

        public UniTask<DigitalStorePopupResult> WaitForResult()
        {
            _tcs = new UniTaskCompletionSource<DigitalStorePopupResult>();
            return _tcs.Task;
        }

        public void OnPurchaseCurrencyPackButtonClick(CurrencyPackData currencyPackData)
        {
            var interactionResult = new DigitalStorePopupResult{SelectedPack = currencyPackData, IsCanceled = false};
            _tcs.TrySetResult(interactionResult);
            Close();
        }

        public void OnCloseButtonClick()
        {
            var interactionResult = new DigitalStorePopupResult{ IsCanceled = false};
            _tcs.TrySetResult(interactionResult);
            Close();
        }

        #endregion
    }
}