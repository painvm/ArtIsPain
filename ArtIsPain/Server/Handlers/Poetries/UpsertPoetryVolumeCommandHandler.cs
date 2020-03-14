using ArtIsPain.Server.Commands.Poetry;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Poetry;
using ArtIsPain.Server.ViewModels.Writer;
using ArtIsPain.Shared.Models;
using AutoMapper;
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
            PoetryVolumeViewModel poetryVolumeViewModel = await base.Send(request, cancellationToken, null);

            IQueryable<PoetryVolumeAuthorship> authorship = _poetryVolumeAuthorshipRepository.SetAuthorship(poetryVolumeViewModel.Id, request.AuthorIds);
            IQueryable<Writer> authors = authorship.Select(x => x.Author);

            poetryVolumeViewModel.Authors = _autoMapper.ProjectTo<WriterPreview>(authors).ToList();

            return poetryVolumeViewModel;
        }
    }
}