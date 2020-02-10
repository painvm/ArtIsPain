using ArtIsPain.Shared.Models;
using System;

namespace ArtIsPain.Shared
{
    public class MusicalAlbum : Volume, IAuthorized
    {
        public string Url { get; set; }

        public Guid AuthorId { get; set; }

        public AlbumCover Image { get; set; }
    }
}