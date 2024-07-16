using System;
using Blast.DataLayer;
using Blast.VisualLayer.Gameplay.Handlers;
using TMPro;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Gameplay.UI
{
    public class GameplayHudUi : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private TextMeshProUGUI _coinsBalanceText;

        [SerializeField]
        private TextMeshProUGUI _gemsBalanceText;
        
        #endregion
        
        #region Injects

        [Inject]
        private IHudBackClickHandler _backClickHandler;

        [Inject]
        private IDataLayer _dataLayer;
        
        #endregion

        #region Methods

        private void Start()
        {
            InitializeView();
        }

        private void OnDestroy()
        {
            _dataLayer.Balances.CoinsBalanceChange -= SyncUiWithData;
            _dataLayer.Balances.GemsBalanceChange -= SyncUiWithData;
        }

        private void InitializeView()
        {
            _dataLayer.Balances.CoinsBalanceChange += SyncUiWithData;
            _dataLayer.Balances.GemsBalanceChange += SyncUiWithData;
            
            SyncUiWithData();
        }

        private void SyncUiWithData()
        {
            _coinsBalanceText.text = _dataLayer.Balances.Coins.ToString();
            _gemsBalanceText.text = _dataLayer.Balances.Gems.ToString();
        }

        public async void OnBackButtonClick()
        {
            _backClickHandler.Execute();
        }

        #endregion
    }
}