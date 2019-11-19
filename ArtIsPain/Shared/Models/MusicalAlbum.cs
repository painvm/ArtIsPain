using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class MusicalAlbum : Volume, IAuthorized
    {
        public string Url { get; set; }

        public Guid AuthorId { get; set; }
    }
}