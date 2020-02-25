using ArtIsPain.Server.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Commands
{
    public interface IUpsertAuthorizedEntityCommand<TResponse> : IUpsertEntityCommand<TResponse> where TResponse : IViewModel
    {
        public IEnumerable<Guid> AuthorIds { get; set; }
    }
}