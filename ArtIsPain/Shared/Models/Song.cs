using ArtIsPain.Shared.Interfaces;
using System;

namespace ArtIsPain.Shared.Models
{
    public class Song : ITitled, IEntity, IVolumeItem
    {
        public Guid Id { get; set; }

        public int ObjectTypeId { get; set; }

        public Guid? VolumeId { get; set; }

        public string Title { get; set; }

        public TimeSpan Length { get; set; }

        public int Order { get; set; }

        public bool IsBonusTrack { get; set; }

        public MusicalAlbum Album { get; set; }
    }
}