using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public abstract class VolumeEntity : IObjectType, ITitled
    {
        public Guid Id { get; set; }

        public int ObjectTypeId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime CompletedDate { get; set; }
    }
}