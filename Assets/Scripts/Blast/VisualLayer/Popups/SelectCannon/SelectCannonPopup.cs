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
        
        public class Factory: PlaceholderFactory<SelectCannonPopup> { }
        
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

        private UniTaskCompletionSource<SelectCannonPopupResult> _tcs;
        
        #endregion
        
        #region Injects

        [Inject]
        private SelectCannonToggle.Factory _toggleFactory;
        
        [Inject]
        private IDataLayer _dataLayer;
        
        #endregion
        
        #region Methods

        private void Start()
        {
            CreateCannonToggles();
            _okButton.interactable = IsAnyToggleSelected();
        }

        private void CreateCannonToggles()
        {
            var existingCannons = _dataLayer.Metadata.GetCannonsMetadata();
            foreach (var cannonMetadata in existingCannons)
            {
                var toggleInstance = _toggleFactory.Create(_togglesParentTransform, cannonMetadata);
                toggleInstance.Clicked += OnToggleClicked;
                _toggles.Add(toggleInstance); //so we can choose and get the data when cannon selected
            }
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
            var result = new SelectCannonPopupResult { IsCanceled = true};
            _tcs.TrySetResult(result);
            Close();
        }

        public void OnOkButtonClick()
        {
            var result = new SelectCannonPopupResult { SelectedCannonType = _selectedToggle.CannonMetadata.CannonType };
            _tcs.TrySetResult(result);
            Close();
        }

        public UniTask<SelectCannonPopupResult> WaitForResult()
        {
            _tcs = new UniTaskCompletionSource<SelectCannonPopupResult>();
            return _tcs.Task;
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