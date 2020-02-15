using ArtIsPain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ArtIsPain.Server.Data.Repositories
{
    public class BandRepository : Repository<Band, DbContext>
    {
        private readonly DataContext _dataContext;

        public BandRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}