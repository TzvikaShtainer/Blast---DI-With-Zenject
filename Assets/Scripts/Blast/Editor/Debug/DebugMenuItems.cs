using Blast.VisualLayer.Popups.DigitalStore;
using Blast.VisualLayer.Popups.SelectCannon;
using Blast.VisualLayer.Popups.YesNo;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Blast.Editor.Debug
{
	public static class DebugMenuItems
	{
		[MenuItem("Blast/Popups/Select Cannon Popup")]
		public static void ShowSelectCannonPopup()
		{
			
		}
		
		[MenuItem("Blast/Popups/Yes No Popup")]
		public static void ShowYesNoPopup()
		{
		}
		
		[MenuItem("Blast/Popups/Digital Store Popup")]
		public static void ShowDigitalStorePopup()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			
			var context = Object.FindObjectOfType<SceneContext>();
			if (context == null)
			{
				return;
			}
			
			var popupFactory = context.Container.Resolve<DigitalStorePopup.Factory>();
			popupFactory.Create();
		}
	}
}