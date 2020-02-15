using ArtIsPain.Shared.Interfaces;
using ArtIsPain.Shared.Models;
using System;

namespace ArtIsPain.Shared
{
    public class Photo : IEntity, IVolumeItem, ITitled, IDescribable
    {
        public int Order { get; set; }

        public Guid? VolumeId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid Id { get; set; }

        public int ObjectTypeId { get; set; }

        public Guid? ImageId { get; set; }

        public PhotoObject Image { get; set; }
    }
}