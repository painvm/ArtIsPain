using ArtIsPain.Server.ViewModels;
using MediatR;
using System;

namespace ArtIsPain.Server.Commands
{
    public interface IUpsertEntityCommand<out TResponse> : IRequest<TResponse> where TResponse : IViewModel
    {
        public Guid? EntityId { get; set; }
    }
}