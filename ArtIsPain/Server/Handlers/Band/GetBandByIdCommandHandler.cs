using ArtIsPain.Server.Commands;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Dtos;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.Band
{
    public class GetBandByIdCommandHandler : IRequestHandler<GetBandByIdCommand, BandDto>
    {
        private readonly IMapper _autoMapper;
        private readonly IRepository<ArtIsPain.Shared.Models.Band> _bandRepository;
        private readonly IMediator _mediator;

        public GetBandByIdCommandHandler(IMapper autoMapper, IRepository<ArtIsPain.Shared.Models.Band> bandRepository, IMediator mediator)
        {
            _autoMapper = autoMapper;
            _bandRepository = bandRepository;
            _mediator = mediator;
        }

        public async Task<BandDto> Handle(GetBandByIdCommand request, CancellationToken cancellationToken)
        {
            ArtIsPain.Shared.Models.Band band = await _bandRepository.GetById(request.BandId);

            if (band == null)
            {
                return null;
            }

            BandDto bandToReturn = _autoMapper.Map<BandDto>(band);

            return bandToReturn;
        }
    }
}