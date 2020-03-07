using ArtIsPain.Shared.Models;

namespace ArtIsPain.Server.Data.Repositories
{
    public class BandRepository : EntityRepository<Band, DataContext>
    {
        public BandRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}