using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.ViewModels.Album;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlbumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("byBandId/{bandId}")]
        public async Task<ICollection<AlbumPreviewModel>> GetAlbumsByBandById(Guid bandId)
        {
            GetAlbumsByBandIdCommand request = new GetAlbumsByBandIdCommand() { BandId = bandId };

            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<AlbumViewModel> UpsertBand(UpsertAlbumCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}