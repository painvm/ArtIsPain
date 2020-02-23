using ArtIsPain.Server.Commands.Poetry;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Poetry;
using ArtIsPain.Shared.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _autoMapper;
        private readonly IAuthorizedRepository<PoetryVolumeAuthorship> _authorizedRepository;

        public GetPoetryVolumesByAuthorIdCommandHandler(
            IMapper autoMapper,
            IAuthorizedRepository<PoetryVolumeAuthorship> authorizedRepository)
        {
            _autoMapper = autoMapper;
            _authorizedRepository = authorizedRepository;
        }

        public async Task<IEnumerable<PoetryVolumeViewModel>> Handle(GetPoetryVolumesByAuthorIdCommand request, CancellationToken cancellationToken)
        {
            IQueryable<PoetryVolumeAuthorship> authorizedVolumes = _authorizedRepository
                .GetEntitiesByAuthorId(
                    request.AuthorId,
                    inc => inc.Include(x => x.Author)
                              .Include(x => x.PoetryVolume));

            IQueryable<PoetryVolumeViewModel> volumesToReturn = _autoMapper.ProjectTo<PoetryVolumeViewModel>(authorizedVolumes);

            return await volumesToReturn.ToListAsync();
        }
    }
}