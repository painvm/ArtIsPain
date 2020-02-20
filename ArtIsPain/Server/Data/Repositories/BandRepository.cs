using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtIsPain.Server.Data.Repositories
{
    public class BandRepository : Repository<Band, DataContext>
    {
        public BandRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}