using ArtIsPain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Repositories
{
    public class AlbumRepository : AuthorisedEntityRepository<MusicalAlbum, DataContext>
    {
        public AlbumRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}