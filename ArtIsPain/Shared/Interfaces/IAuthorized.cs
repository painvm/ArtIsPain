using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public interface IAuthorized
    {
        Guid AuthorId { get; set; }
    }
}