using ArtIsPain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Repositories
{
    public class SongRepository : EntityRepository<Song, DataContext>
    {
        public SongRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
