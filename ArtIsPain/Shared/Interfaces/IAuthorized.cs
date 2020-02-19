using System;

namespace ArtIsPain.Shared
{
    public interface IAuthorized
    {
        Guid? AuthorId { get; set; }
    }
}