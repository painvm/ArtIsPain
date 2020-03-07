using ArtIsPain.Server.ViewModels;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Server.Commands
{
    public interface IUpsertAuthorizedEntityCommand<TResponse> : IUpsertEntityCommand<TResponse> where TResponse : IViewModel
    {
        public IEnumerable<Guid> AuthorIds { get; set; }
    }
}