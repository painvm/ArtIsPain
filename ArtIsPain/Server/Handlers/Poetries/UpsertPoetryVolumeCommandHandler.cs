using ArtIsPain.Server.Commands.Poetry;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Poetry;
using ArtIsPain.Shared.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.Poetries
{
    public class UpsertPoetryVolumeCommandHandler : BaseUpsertEntityCommandHandler<PoetryVolume, UpsertPoetryVolumeCommand, PoetryVolumeViewModel>
    {
        private readonly IMultiAuthorizedRepository<PoetryVolumeAuthorship> _poetryVolumeAuthorshipRepository;

        public UpsertPoetryVolumeCommandHandler(
            IMapper autoMapper,
            IRepository<PoetryVolume> poetryVolumeRepository,
            IMultiAuthorizedRepository<PoetryVolumeAuthorship> poetryVolumeAuthorshipRepository) : base(autoMapper, poetryVolumeRepository)
        {
            _poetryVolumeAuthorshipRepository = poetryVolumeAuthorshipRepository;
        }

        protected override async Task<PoetryVolumeViewModel> Send(UpsertPoetryVolumeCommand request, CancellationToken cancellationToken)
        {
            Func<IQueryable<PoetryVolume>, IQueryable<PoetryVolume>> addJoinStatement =
                x => x.Include(pv => pv.PoetryVolumeAuthorships);
            PoetryVolumeViewModel poetryVolumeViewModel = await base.Send(request, cancellationToken, addJoinStatement);

            return poetryVolumeViewModel;
        }
    }
}