using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public interface IVolumeItem
    {
        int Order { get; set; }
        Guid VolumeId { get; set; }
    }
}