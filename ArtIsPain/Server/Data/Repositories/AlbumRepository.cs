using ArtIsPain.Shared.Models;
using System;
using System.Linq;

namespace ArtIsPain.Server.Data.Repositories
{
    public class AlbumRepository : AuthorisedEntityRepository<MusicalAlbum, DataContext>
    {
        public AlbumRepository(DataContext dataContext) : base(dataContext)
        {
    
        }
    }
}