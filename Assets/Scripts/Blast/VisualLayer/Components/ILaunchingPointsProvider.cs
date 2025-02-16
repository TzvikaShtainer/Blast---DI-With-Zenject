using UnityEngine;

namespace Blast.VisualLayer.Components
{
    public interface ILaunchingPointsProvider
    {
        Transform[] LaunchingPoints{ get; }
    }
}