using ArtIsPain.Server.Commands.Poetry;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Handlers.Band;
using ArtIsPain.Server.ViewModels.Poetry;
using ArtIsPain.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.Poetries
{
    public class UpsertPoetryVolumeCommandHandler : BaseUpsertEntityCommandHandler<PoetryVolume, UpsertPoetryVolumeCommand, PoetryVolumeViewModel>
    {
        private readonly IAuthorizedRepository<PoetryVolumeAuthorship> _poetryVolumeAuthorshipRepository;

        public UpsertPoetryVolumeCommandHandler(
            IMapper autoMapper,
            IRepository<PoetryVolume> poetryVolumeRepository,
            IAuthorizedRepository<PoetryVolumeAuthorship> poetryVolumeAuthorshipRepository) : base(autoMapper, poetryVolumeRepository)
        {
            _poetryVolumeAuthorshipRepository = poetryVolumeAuthorshipRepository;
        }

        public override async Task<PoetryVolumeViewModel> Handle(UpsertPoetryVolumeCommand request, CancellationToken cancellationToken)
        {
            PoetryVolumeViewModel poetryVolumeViewModel = await base.Handle(request, cancellationToken);

            _poetryVolumeAuthorshipRepository.SetAuthorship()
        }
    }
}