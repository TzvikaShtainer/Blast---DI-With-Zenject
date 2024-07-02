using Blast.VisualLayer.Gameplay.Handlers;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Blast.VisualLayer.CannonStudio.Handlers
{
    public class MockBackClickHandler : IHudBackClickHandler
    {
        public async UniTask Execute()
        {
            Debug.Log("you press back btn");
        }
    }
}