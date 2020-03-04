using ArtIsPain.Shared.Interfaces;
using System;

namespace ArtIsPain.Shared.Models
{
    public class PoetryVolumeAuthorship : IMultiAuthorized
    {
        public Guid EntityId { get; set; }

        public Guid? AuthorId { get; set; }

        public PoetryVolume PoetryVolume { get; set; }

        public Writer Author { get; set; }
    }
}