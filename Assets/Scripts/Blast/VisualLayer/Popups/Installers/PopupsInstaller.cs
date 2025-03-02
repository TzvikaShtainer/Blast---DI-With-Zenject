using Blast.VisualLayer.Popups.DigitalStore;
using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Popups.Installers
{
    public class PopupsInstaller : MonoInstaller<PopupsInstaller>
    {
        [SerializeField]
        private RectTransform _parentPopupCanvasTransform;
        
        [SerializeField]
        private DigitalStorePopup _storePopupPrefabRef;
        
        public override void InstallBindings()
        {
            Container
                .BindFactory<DigitalStorePopup, DigitalStorePopup.Factory>()
                .FromComponentInNewPrefab(_storePopupPrefabRef)
                .UnderTransform(_parentPopupCanvasTransform)
                .AsSingle();
        }
    }
}