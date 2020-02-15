using System;

namespace ArtIsPain.Shared
{
    public interface IEntityWithImage
    {
        Guid? ImageId { get; set; }
    }
}