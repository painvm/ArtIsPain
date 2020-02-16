using ArtIsPain.Shared.Interfaces;
using System;

namespace ArtIsPain.Shared.Models
{
    public abstract class Person : IEntity, IEntityWithImage, IDescribable
    {
        public Guid Id { get; set; }

        public int ObjectTypeId { get; set; }

        public Guid? ImageId { get; set; }

        public string Description { get; set; }
    }
}