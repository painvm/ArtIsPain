using ArtIsPain.Shared.Models;

namespace ArtIsPain.Server.Data.Repositories
{
    public class PoetryVolumeRepository : EntityRepository<PoetryVolume, DataContext>
    {
        public PoetryVolumeRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}