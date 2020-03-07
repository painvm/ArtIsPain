using ArtIsPain.Server.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Server.Commands
{
    public interface IGetEntitiesByAuthorIdCommand<TResponse> : IRequest<TResponse> where TResponse : IEnumerable<IViewModel>
    {
        public Guid AuthorId { get; set; }
    }
}