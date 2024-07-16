using Blast.DataLayer.Metadata;

namespace Blast.DataLayer
{
    public interface IDataLayer
    { 
        IGameMetadata Metadata { get; }
    }
}