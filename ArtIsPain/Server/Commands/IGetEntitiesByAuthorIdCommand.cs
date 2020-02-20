using ArtIsPain.Server.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Commands
{
    public interface IGetEntitiesByAuthorIdCommand<TResponse> : IRequest<TResponse> where TResponse : IEnumerable<IViewModel>
    {
        public Guid AuthorId { get; set; }
    }
}