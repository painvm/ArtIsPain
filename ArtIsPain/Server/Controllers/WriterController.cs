using ArtIsPain.Server.Commands.Writers;
using ArtIsPain.Server.ViewModels.Writer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{writerId}")]
        public async Task<WriterViewModel> GetBandById(Guid writerId)
        {
            GetWriterByIdCommand request = new GetWriterByIdCommand() { EntityId = writerId };

            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<WriterViewModel> UpsertWriter(UpsertWriterCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}