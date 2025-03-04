using Blast.VisualLayer.Popups.DigitalStore;
using Blast.VisualLayer.Popups.YesNo;
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
        
        [SerializeField]
        private YesNoPopup _yesNoPopupPrefabRef;
        
        public override void InstallBindings()
        {
            Container
                .BindFactory<DigitalStorePopup, DigitalStorePopup.Factory>()
                .FromComponentInNewPrefab(_storePopupPrefabRef)
                .UnderTransform(_parentPopupCanvasTransform)
                .AsSingle();
            
            Container
                .BindFactory<YesNoPopupArgs, YesNoPopup, YesNoPopup.Factory>()
                .FromComponentInNewPrefab(_yesNoPopupPrefabRef)
                .UnderTransform(_parentPopupCanvasTransform)
                .AsSingle();
        }
    }
}