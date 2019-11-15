using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class Story : TextEntity, IObjectTypeWithImage
    {
        public Guid ImageId { get; set; }
    }
}