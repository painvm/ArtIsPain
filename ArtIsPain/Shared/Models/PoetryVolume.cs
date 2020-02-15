using ArtIsPain.Shared.Models;
using System.Collections.Generic;

namespace ArtIsPain.Shared
{
    public class PoetryVolume : Volume
    {
        public ICollection<PoetryVolumeAuthorship> PoetryVolumeAuthorships { get; set; }
    }
}