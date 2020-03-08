using System;

namespace ArtIsPain.Shared.Interfaces
{
    public interface IEntityWithImage
    {
        Guid? ImageId { get; set; }
    }
}