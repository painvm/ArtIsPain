using ArtIsPain.Server.Commands.Writers;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Models;
using ArtIsPain.Server.ViewModels.Poetry;
using ArtIsPain.Server.ViewModels.Writer;
using ArtIsPain.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.Writers
{
    public class GetWriterByIdCommandHandler : BaseGetEntityByIdHandler<Writer, GetWriterByIdCommand, WriterViewModel>
    {
        private readonly IMultiAuthorizedRepository<PoetryVolumeAuthorship> _poetryVolumeAuthorshipRepository;
        private readonly IMapper _autoMapper;

        public GetWriterByIdCommandHandler(
            IMapper autoMapper,
            IRepository<Writer> writerRepository,
            IMultiAuthorizedRepository<PoetryVolumeAuthorship> poetryVolumeAuthorshipRepository) : base(autoMapper, writerRepository)
        {
            _poetryVolumeAuthorshipRepository = poetryVolumeAuthorshipRepository;
            _autoMapper = autoMapper;
        }

        public override async Task<WriterViewModel> Handle(GetWriterByIdCommand request, CancellationToken cancellationToken)
        {
            WriterViewModel writer = await base.Handle(request, cancellationToken);

            var authoredPoetryVolumes =
                 _poetryVolumeAuthorshipRepository
                    .GetByAuthorId(request.EntityId)
                        .Select(x => x.PoetryVolume);

            writer.PoetryVolumes = _autoMapper.ProjectTo<PoetryVolumePreviewModel>(authoredPoetryVolumes).ToList();

            return writer;
        }
    }
}