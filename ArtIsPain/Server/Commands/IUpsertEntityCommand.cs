using ArtIsPain.Server.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Commands
{
    public interface IUpsertEntityCommand<TResponse> : IRequest<TResponse> where TResponse : IResult
    {
        public Guid? EntityId { get; set; }
    }
}