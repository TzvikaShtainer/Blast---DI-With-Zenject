using Blast.DataLayer.Balances;
using Blast.DataLayer.Metadata;

namespace Blast.DataLayer
{
    public interface IDataLayer
    { 
        IGameMetadata Metadata { get; }
        
        IPlayerBalances Balances { get; }
    }
}