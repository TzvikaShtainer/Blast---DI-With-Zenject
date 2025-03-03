using Blast.DataLayer;
using Blast.VisualLayer.SelectLevel.Handlers;
using TMPro;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.SelectLevel.UI
{
    public class SelectLevelHudUi : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private TextMeshProUGUI _coinsBalanceText;

        [SerializeField]
        private TextMeshProUGUI _gemsBalanceText;
        
        #endregion
        
        #region Injects
        
        [Inject]
        private IHudPlusCurrencyClickHandler _plusCurrencyHandler;
        #endregion
        
        #region Methods

        private void Start()
        {
            InitializeView();
        }

        private void InitializeView()
        {
            SyncUiWithData();
        }

        private void SyncUiWithData()
        {
        }

        public async void OnSettingsButtonClick()
        {
        }

        public async void OnCoinsPlusButtonClick()
        {
            _plusCurrencyHandler.Execute();
        }
        
        public async void OnGemsPlusButtonClick()
        {
        }

        #endregion
    }
}