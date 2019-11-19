using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public abstract class Text : IEntity, ITitled
    {
        public Guid Id { get; set; }

        public int ObjectTypeId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}