using UnityEngine;
using Zenject;

namespace Blast.VisualLayer.Gameplay.Score
{
    [CreateAssetMenu(menuName = "Blast/Score/Score Calculator", fileName = "Score Calculator")]
    public class GameScoreCalculatorInstaller : ScriptableObjectInstaller<GameScoreCalculatorInstaller>
    {
        [SerializeField] 
        private ScoreCalculationParams _params;
        
        public override void InstallBindings()
        {
            Container
                .Bind<ScoreCalculationParams>()
                .FromInstance(_params)
                .AsSingle();

            Container
                .Bind<IInitializable>()
                .To<SignalBasedGameScoreCalculator>()
                .AsSingle();
        }
    }
}