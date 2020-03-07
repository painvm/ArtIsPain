using ArtIsPain.Server.Commands.Band;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Filters.BaseFilters;
using ArtIsPain.Shared.Models;

namespace ArtIsPain.Server.Filters
{
    public class UpsertBandCommandFilter : UpsertEntityCommandFilter<UpsertBandCommand, Band>
    {
        public UpsertBandCommandFilter(IRepository<Band> bandRepository) : base(bandRepository)
        {
        }
    }
}