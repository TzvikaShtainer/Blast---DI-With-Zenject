using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Blast.VisualLayer.Popups.YesNo
{
    public class YesNoPopup : Popup
    {
        #region Factories
        #endregion
        
        #region Editor

        [SerializeField]
        private TextMeshProUGUI _yesButtonText;

        [SerializeField]
        private TextMeshProUGUI _noButtonText;
        
        [SerializeField]
        private GameObject _noButtonGameObject;

        [SerializeField]
        private TextMeshProUGUI _popupContent;
        
        #endregion
        
        #region Fields

        #endregion
        
        #region Methods

        [Inject]
        public void Construct(YesNoPopupArgs args)
        {
            _popupContent.text = args.Text;
            _yesButtonText.text = args.YesCaption;
            _noButtonText.text = args.NoCaption;
            _noButtonGameObject.SetActive(args.IsNoButtonVisible);
        }

        public UniTask<YesNoPopupResult> WaitForResult()
        {
            return default;
        }

        public void OnYesClick()
        {
            Close();
        }

        public void OnCancelClick()
        {
            Close();
        }

        #endregion
    }
}