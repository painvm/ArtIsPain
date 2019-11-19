using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public interface IEntityWithImage
    {
        Guid ImageId { get; set; }
    }
}