using Blast.VisualLayer.Cannons.Components;

namespace Blast.VisualLayer.Enemies.Spawners
{
    public interface IEnemySpawner
    {
        void BeginSpawning(IEnemyTarget target);
        
        void StopSpawning();
    }
}