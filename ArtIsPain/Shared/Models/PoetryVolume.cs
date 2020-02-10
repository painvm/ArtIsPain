using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class PoetryVolume : Volume
    {
        public ICollection<Writer> Authors { get; set; }
    }
}