using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtIsPain.Server.Commands.Writers;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Writer;
using ArtIsPain.Shared.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<WriterViewModel> UpsertWriter(UpsertWriterCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}