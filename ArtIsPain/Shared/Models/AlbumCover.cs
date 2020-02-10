using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared.Models
{
    public class AlbumCover : Image
    {
        public MusicalAlbum Album { get; set; }
    }
}
