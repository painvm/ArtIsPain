using ArtIsPain.Shared.Interfaces;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Shared.Models
{
    public class MusicalAlbum : Volume, IAuthorized
    {
        public string Url { get; set; }

        public Guid? AuthorId { get; set; }

        public AlbumCover Image { get; set; }

        public Band Band { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}