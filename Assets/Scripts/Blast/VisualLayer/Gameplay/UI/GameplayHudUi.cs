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

        public async void OnBackButtonClick()
        {
        }

        #endregion
    }
}