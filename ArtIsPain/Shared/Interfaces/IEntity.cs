using System;

namespace ArtIsPain.Shared.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
        int ObjectTypeId { get; set; }
    }
}