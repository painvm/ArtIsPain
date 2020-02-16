using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Repositories
{
    public class AlbumRepository : Repository<MusicalAlbum, DbContext>
    {
        private readonly DataContext _dataContext;

        public AlbumRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<MusicalAlbum> GetAlbumsByBandId(Guid bandId)
        {
            IQueryable<MusicalAlbum> albums = _dataContext.MusicalAlbums
                                                          .Where(a => a.AuthorId == bandId);

            return albums;
        }
    }
}