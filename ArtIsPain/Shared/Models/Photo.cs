using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class Photo : ImageEntity, IVolumeItem
    {
        public int Order { get; set; }
        public Guid VolumeId { get; set; }
    }
}