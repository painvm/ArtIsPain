using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class Cover : Image
    {
        public Guid ObjectToCoverId { get; set; }
        public Guid ObjectToCoverTypeId { get; set; }
    }
}