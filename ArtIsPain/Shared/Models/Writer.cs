using ArtIsPain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class Writer : Artist
    {
        public ICollection<PoetryVolumeAuthorship> PoetryVolumeAuthorships { get; set; }

        public ICollection<StoryAuthorship> StoryAuthorships { get; set; }
    }
}