using ArtIsPain.Shared;
using System.Linq;

namespace ArtIsPain.Server.Data.Interfaces
{
    public interface ISeedDataBuilder
    {
        IQueryable<IEntity> CreateSeedData();
    }
}