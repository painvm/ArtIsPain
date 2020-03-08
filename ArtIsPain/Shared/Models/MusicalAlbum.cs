using ArtIsPain.Shared.Interfaces;
using System;

namespace ArtIsPain.Shared.Models
{
    public class MusicalAlbum : Volume, IAuthorized
    {
        public string Url { get; set; }

        public Guid? AuthorId { get; set; }

        public AlbumCover Image { get; set; }

        public Band Band { get; set; }
    }
}