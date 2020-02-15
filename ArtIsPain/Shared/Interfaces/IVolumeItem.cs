using System;

namespace ArtIsPain.Shared
{
    public interface IVolumeItem
    {
        int Order { get; set; }
        Guid? VolumeId { get; set; }
    }
}