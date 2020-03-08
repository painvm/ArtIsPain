using ArtIsPain.Shared;
using ArtIsPain.Shared.Interfaces;
using System.Linq;

namespace ArtIsPain.Server.Data.Interfaces
{
    public interface ISeedDataBuilder
    {
        IQueryable<IEntity> CreateSeedData();
    }
}