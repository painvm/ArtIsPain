using System;

namespace ArtIsPain.Shared.Models
{
    public class PoetryVolumeAuthorship
    {
        public Guid PoetryVolumeId { get; set; }

        public Guid AuthorId { get; set; }

        public PoetryVolume PoetryVolume { get; set; }

        public Writer Author { get; set; }
    }
}