using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared.Interfaces
{
    public interface IMultiAuthorized : IAuthorized
    {
        Guid EntityId { get; set; }
    }
}