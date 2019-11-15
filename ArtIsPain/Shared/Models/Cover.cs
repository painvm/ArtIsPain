using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class Cover : ImageEntity
    {
        public Guid ObjectToCoverId { get; set; }
        public Guid ObjectToCoverTypeId { get; set; }
    }
}