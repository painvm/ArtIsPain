using ArtIsPain.Server.Commands.Writers;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Poetry;
using ArtIsPain.Server.ViewModels.Writer;
using ArtIsPain.Shared.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.Writers
{
    public class GetWriterByIdCommandHandler : BaseGetEntityByIdHandler<Writer, GetWriterByIdCommand, WriterViewModel>
    {
        public GetWriterByIdCommandHandler(
            IMapper autoMapper,
            IRepository<Writer> writerRepository) : base(autoMapper, writerRepository)
        {
        }

        protected override async Task<WriterViewModel> Send(GetWriterByIdCommand request, CancellationToken cancellationToken)
        {
            Func<IQueryable<Writer>, IQueryable<Writer>> include =
                    x => x.Include(w => w.PoetryVolumeAuthorships).ThenInclude(w => w.Author)
                          .Include(w => w.PoetryVolumeAuthorships).ThenInclude(w => w.PoetryVolume);

            WriterViewModel writer = await base.Send(request, cancellationToken, include);

            return writer;
        }
    }
}