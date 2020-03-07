using ArtIsPain.Shared.Models;

namespace ArtIsPain.Server.Data.Repositories
{
    public class AlbumRepository : AuthorisedEntityRepository<MusicalAlbum, DataContext>
    {
        public AlbumRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}