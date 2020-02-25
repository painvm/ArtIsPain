using ArtIsPain.Server.Commands.Writers;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Handlers.Band;
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
    public class UpsertWriterCommandHandler : BaseUpsertEntityCommandHandler<Writer, UpsertWriterCommand, WriterViewModel>
    {
        public UpsertWriterCommandHandler(IMapper autoMapper, IRepository<Writer> writerRepository) : base(autoMapper, writerRepository)
        {
        }

        public override async Task<WriterViewModel> Handle(UpsertWriterCommand request, CancellationToken cancellationToken)
        {
            WriterViewModel writerResponse = await base.Handle(request, cancellationToken);

            return writerResponse;
        }
    }
}