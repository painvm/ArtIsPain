using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtIsPain.Server.Commands.Poetry;
using ArtIsPain.Server.ViewModels.Poetry;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtIsPain.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoetryVolumeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PoetryVolumeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<PoetryVolumeViewModel> UpsertPoetryVolume(UpsertPoetryVolumeCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}