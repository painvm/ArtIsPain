using System;

namespace ArtIsPain.Shared.Interfaces
{
    public interface IAuthorized
    {
        Guid? AuthorId { get; set; }
    }
}