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

        public BandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets musical band by id
        /// </summary>
        [HttpGet("{bandId}")]
        public async Task<BandViewModel> GetBandById(Guid bandId)
        {
            GetBandByIdCommand request = new GetBandByIdCommand() { EntityId = bandId };

            return await _mediator.Send(request);
        }

        /// <summary>
        /// Creates a new musical band profile or updates already existing one
        /// </summary>
        [HttpPost]
        public async Task<BandViewModel> UpsertBand(UpsertBandCommand request) => await _mediator.Send(request);
    }
}