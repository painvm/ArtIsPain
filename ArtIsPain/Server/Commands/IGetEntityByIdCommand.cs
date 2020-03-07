using ArtIsPain.Server.ViewModels;
using MediatR;
using System;

namespace ArtIsPain.Server.Commands
{
    public interface IGetEntityByIdCommand<TResponse> : IRequest<TResponse> where TResponse : IViewModel
    {
        public Guid EntityId { get; set; }
    }
}