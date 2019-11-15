using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public interface IObjectTypeWithImage
    {
        Guid ImageId { get; set; }
    }
}