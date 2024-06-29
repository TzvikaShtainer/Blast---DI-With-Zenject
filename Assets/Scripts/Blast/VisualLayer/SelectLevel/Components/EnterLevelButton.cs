using Blast.DataTypes;
using Blast.VisualLayer.SelectLevel.Handlers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Blast.VisualLayer.SelectLevel.Components
{
    public class EnterLevelButton : MonoBehaviour
    {
        #region Factories
        #endregion
        
        #region Editor

        [SerializeField]
        private TextMeshProUGUI _levelNameComponent;
        
        [SerializeField]
        private string _levelName;

        [SerializeField]
        private Image _buttonCoverImage;
        
        #endregion

        #region Injects
        #endregion

        #region Fields

        private GameLevelMetadata _levelMetadata;

        #endregion
        
        #region Methods

        [Inject]
        public void Construct(GameLevelMetadata levelMetadata)
        {
            _levelMetadata = levelMetadata;
            _levelName = _levelMetadata.LevelName;
            _levelNameComponent.text = _levelName;
            _buttonCoverImage.sprite = _levelMetadata.SceneCoverSprite;
        }

        private void OnValidate()
        {
            _levelNameComponent.text = _levelName;
        }

        public void OnClick()
        {
        }

        #endregion
    }
}