using System;

namespace ArtIsPain.Shared.Interfaces
{
    public interface IMultiAuthorized : IAuthorized
    {
        Guid EntityId { get; set; }
    }
}