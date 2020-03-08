using System;

namespace ArtIsPain.Shared.Interfaces
{
    public interface IVolumeItem
    {
        int Order { get; set; }
        Guid? VolumeId { get; set; }
    }
}