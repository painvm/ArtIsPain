using ArtIsPain.Server.Commands.Band;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Dtos.Band;
using ArtIsPain.Shared.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.BandHandlers
{
    public class UpsertBandCommandHandler : IRequestHandler<UpsertBandCommand, BandResult>
    {
        private readonly IMapper _autoMapper;
        private readonly IRepository<Band> _bandRepository;

        public UpsertBandCommandHandler(IMapper autoMapper, IRepository<Band> bandRepository)
        {
            this._autoMapper = autoMapper;
            this._bandRepository = bandRepository;
        }

        public async Task<BandResult> Handle(UpsertBandCommand request, CancellationToken cancellationToken)
        {
            Band bandToUpsert = request.Id.HasValue
                ? await _bandRepository.GetById(request.Id.Value)
                : new Band();
            _autoMapper.Map(request, bandToUpsert);

            Band upsertedBand = await _bandRepository.Upsert(bandToUpsert);
            BandResult result = new BandResult();

            _autoMapper.Map(upsertedBand, result);

            return result;
        }
    }
}