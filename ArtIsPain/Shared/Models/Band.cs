using System.Collections.Generic;

namespace ArtIsPain.Shared.Models
{
    public class Band : Artist
    {
        public BandLogo Image { get; set; }

        public ICollection<MusicalAlbum> Albums { get; set; }
    }
}