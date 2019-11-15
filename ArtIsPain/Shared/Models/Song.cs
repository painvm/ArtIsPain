using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class Song : ITitled, IObjectType, IVolumeItem
    {
        public Guid Id { get; set; }

        public int ObjectTypeId { get; set; }

        public Guid VolumeId { get; set; }

        public string Title { get; set; }

        public TimeSpan Length { get; set; }

        public int Order { get; set; }

        public bool IsBonusTrack { get; set; }
    }
}