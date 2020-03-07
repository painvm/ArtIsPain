using ArtIsPain.Server.Commands.Band;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Band;
using ArtIsPain.Shared.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BandController(IMapper autoMapper, IRepository<Band> bandRepository, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{bandId}")]
        public async Task<BandViewModel> GetBandById(Guid bandId)
        {
            GetBandByIdCommand request = new GetBandByIdCommand() { EntityId = bandId };

            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<BandViewModel> UpsertBand(UpsertBandCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}