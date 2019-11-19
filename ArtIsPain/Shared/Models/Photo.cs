using ArtIsPain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class Photo : Image, IVolumeItem, ITitled, IDescribable
    {
        public int Order { get; set; }
        public Guid VolumeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}