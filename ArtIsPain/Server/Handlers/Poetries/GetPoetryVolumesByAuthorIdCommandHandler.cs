using ArtIsPain.Server.Commands.Poetry;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Poetry;
using ArtIsPain.Shared.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.Poetries
{
    public class GetPoetryVolumesByAuthorIdCommandHandler : IRequestHandler<GetPoetryVolumesByAuthorIdCommand, IEnumerable<PoetryVolumeViewModel>>
    {
        private readonly IAuthorizedRepository<PoetryVolumeAuthorship> _authorizedRepository;

        public GetPoetryVolumesByAuthorIdCommandHandler(IMapper autoMapper, IAuthorizedRepository<PoetryVolumeAuthorship> authorizedRepository)
        {
            _authorizedRepository = authorizedRepository;
        }

        public Task<IEnumerable<PoetryVolumeViewModel>> Handle(GetPoetryVolumesByAuthorIdCommand request, CancellationToken cancellationToken)
        {
            IQueryable<Guid> poetryVolumeIds = _authorizedRepository.GetEntitiesByAuthorId(
                request.AuthorId).Select(x => x.PoetryVolumeId);

            return null;
        }
    }
}