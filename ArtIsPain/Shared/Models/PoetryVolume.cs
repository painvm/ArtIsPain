using System.Collections.Generic;

namespace ArtIsPain.Shared.Models
{
    public class PoetryVolume : Volume
    {
        public ICollection<PoetryVolumeAuthorship> PoetryVolumeAuthorships { get; set; }
    }
}