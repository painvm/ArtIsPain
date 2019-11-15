using System;

namespace ArtIsPain.Shared
{
    public interface IObjectType
    {
        Guid Id { get; set; }
        int ObjectTypeId { get; set; }
    }
}