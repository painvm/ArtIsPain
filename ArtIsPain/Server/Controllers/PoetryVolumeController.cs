using ArtIsPain.Server.Commands.Poetry;
using ArtIsPain.Server.ViewModels.Poetry;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        /// <summary>
        /// Gets poetry collection by id
        /// </summary>
        [HttpGet("{poetryVolumeId}")]
        public async Task<PoetryVolumeViewModel> GetPoetryVolumeById(Guid poetryVolumeId)
        {
            GetPoetryVolumeByIdCommand request = new GetPoetryVolumeByIdCommand() { EntityId = poetryVolumeId };

            return await _mediator.Send(request);
        }

       /// <summary>
        /// Creates a new poetry collection or updates already existing one
        /// </summary>
        [HttpPost]
        public async Task<PoetryVolumeViewModel> UpsertPoetryVolume(UpsertPoetryVolumeCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}