﻿using ArtIsPain.Server.Commands.Writers;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Writer;
using ArtIsPain.Shared.Models;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.Writers
{
    public class UpsertWriterCommandHandler : BaseUpsertEntityCommandHandler<Writer, UpsertWriterCommand, WriterViewModel>
    {
        public UpsertWriterCommandHandler(IMapper autoMapper, IRepository<Writer> writerRepository) : base(autoMapper, writerRepository)
        {
        }

        protected override async Task<WriterViewModel> Send(UpsertWriterCommand request, CancellationToken cancellationToken)
        {
            WriterViewModel writerResponse = await base.Send(request, cancellationToken, null);

            return writerResponse;
        }
    }
}