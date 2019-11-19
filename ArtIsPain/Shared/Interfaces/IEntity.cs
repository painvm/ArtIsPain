using System;

namespace ArtIsPain.Shared
{
    public interface IEntity
    {
        Guid Id { get; set; }
        int ObjectTypeId { get; set; }
    }
}