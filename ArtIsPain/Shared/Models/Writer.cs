using ArtIsPain.Shared.Models;
using System.Collections.Generic;

namespace ArtIsPain.Shared
{
    public class Writer : Artist
    {
        public ICollection<PoetryVolumeAuthorship> PoetryVolumeAuthorships { get; set; }

        public ICollection<StoryAuthorship> StoryAuthorships { get; set; }
    }
}