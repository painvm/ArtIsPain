using ArtIsPain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public abstract class Person : IEntity, IEntityWithImage, IDescribable
    {
        public Guid Id { get; set; }

        public int ObjectTypeId { get; set; }

        public Guid ImageId { get; set; }

        public string Description { get; set; }
    }
}