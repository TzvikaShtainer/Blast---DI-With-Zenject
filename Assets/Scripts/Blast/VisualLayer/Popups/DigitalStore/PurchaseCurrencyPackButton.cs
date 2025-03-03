using System;
using TMPro;
using UnityEngine;

namespace Blast.VisualLayer.Popups.DigitalStore
{
    public class PurchaseCurrencyPackButton : MonoBehaviour
    {
        [SerializeField]
        private CurrencyPackData _packData;
        
        [SerializeField]
        private TextMeshProUGUI _packNameComponent;
        
        [SerializeField]
        private TextMeshProUGUI _amountComponent;

        private void Start()
        {
            _packNameComponent.text = _packData.PackName;
            _amountComponent.text = $"+{_packData.AdditionAmount.ToString()}";
        }
    }
}