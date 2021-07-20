using ArtIsPain.Server.Commands.Writers;
using ArtIsPain.Server.RequestExamples;
using ArtIsPain.Server.ViewModels.Writer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.RequestExamples;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WriterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets writer profile by id
        /// </summary>
        [HttpGet("{writerId}")]
        public async Task<WriterViewModel> GetBandById(Guid writerId)
        {
            GetWriterByIdCommand request = new GetWriterByIdCommand() { EntityId = writerId };

            return await _mediator.Send(request);
        }

        /// <summary>
        /// Creates a new writer profile, or updates already existing one
        /// </summary>
        [SwaggerRequestExample(typeof(UpsertWriterCommand), typeof(UpsertWriterCommandRequestExample))]
        [SwaggerResponseExample(200, typeof(UpsertWriterCommandResponseExample))]
        [HttpPost]
        public async Task<WriterViewModel> UpsertWriter(UpsertWriterCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}