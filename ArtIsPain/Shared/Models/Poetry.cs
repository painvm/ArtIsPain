using System;

namespace ArtIsPain.Shared
{
    public class Poetry : Text, IVolumeItem
    {
        public int Order { get; set; }

        public Guid? VolumeId { get; set; }

        public PoetryVolume PoetryVolume { get; set; }
    }
}