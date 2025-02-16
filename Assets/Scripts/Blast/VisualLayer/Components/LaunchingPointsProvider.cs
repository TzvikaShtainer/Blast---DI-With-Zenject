using UnityEngine;

namespace Blast.VisualLayer.Components
{
    public class LaunchingPointsProvider : MonoBehaviour, ILaunchingPointsProvider
    {
        [SerializeField]
        private Transform[] _launchingPoints;

        public Transform[] LaunchingPoints => _launchingPoints;
    }
}