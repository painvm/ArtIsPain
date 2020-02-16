using System.Collections.Generic;

namespace ArtIsPain.Shared.Models
{
    public class Writer : Artist
    {
        public ICollection<PoetryVolumeAuthorship> PoetryVolumeAuthorships { get; set; }

        public ICollection<StoryAuthorship> StoryAuthorships { get; set; }
    }
}