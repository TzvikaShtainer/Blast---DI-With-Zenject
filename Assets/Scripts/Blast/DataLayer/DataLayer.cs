using Blast.DataLayer.Balances;
using Blast.DataLayer.Metadata;
using Zenject;

namespace Blast.DataLayer
{
    public class DataLayer : IDataLayer
    {
        [Inject]
        public IGameMetadata Metadata { get; private set; }

        [Inject]
        public IPlayerBalances Balances { get; }
    }
}