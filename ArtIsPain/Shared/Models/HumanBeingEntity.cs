using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public abstract class HumanBeingEntity : IObjectType, IObjectTypeWithImage
    {
        public Guid Id { get; set; }

        public int ObjectTypeId { get; set; }

        public Guid ImageId { get; set; }

        public bool IsActive { get; set; }

        public string Summary { get; set; }
    }
}