using System.Collections.Generic;
using System.Linq;
using Blast.DataLayer;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Blast.VisualLayer.Popups.SelectCannon
{
    public class SelectCannonPopup : Popup
    {
        #region Factories
        #endregion
        
        #region Editor

        [SerializeField]
        private Button _okButton;

        [SerializeField]
        private Transform _togglesParentTransform;
        
        #endregion
        
        #region Fields

        private SelectCannonToggle _selectedToggle;

        private List<SelectCannonToggle> _toggles = new();
        
        #endregion
        
        #region Injects

        #endregion
        
        #region Methods

        private void Start()
        {
            CreateCannonToggles();
            _okButton.interactable = IsAnyToggleSelected();
        }

        private void CreateCannonToggles()
        {
            // TODO: Create toggles list
        }

        private void OnToggleClicked(SelectCannonToggle sender)
        {
            DeselectAllToggles();
            _selectedToggle = sender;
            _selectedToggle.Select();
            _okButton.interactable = IsAnyToggleSelected();
        }

        public void OnCloseButtonClick()
        {
            Close();
        }

        public void OnOkButtonClick()
        {
            Close();
        }

        public UniTask<SelectCannonPopupResult> WaitForResult()
        {
            return default;
        }

        private void DeselectAllToggles()
        {
            _toggles.ForEach(t => t.Deselect());
        }

        private bool IsAnyToggleSelected()
        {
            return _toggles.Count(t => t.IsSelected) > 0;
        }

        #endregion
    }
}