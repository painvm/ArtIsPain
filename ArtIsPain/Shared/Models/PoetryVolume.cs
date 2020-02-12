using ArtIsPain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class PoetryVolume : Volume
    {
        public ICollection<PoetryVolumeAuthorship> PoetryVolumeAuthorships { get; set; }
    }
}