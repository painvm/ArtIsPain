using ArtIsPain.Server.Commands.Album;
using ArtIsPain.Server.ViewModels.Album;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        /// <summary>
        /// Gets musical album by id
        /// </summary>
        /// <param name="albumId">The id of musical album record</param>   
        [HttpGet("{albumId}")]
        public async Task<AlbumViewModel> GetAlbumById(Guid albumId)
        {
            GetAlbumByIdCommand request = new GetAlbumByIdCommand() { EntityId = albumId };

            return await _mediator.Send(request);
        }

        /// <summary>
        /// Gets musical album by band id
        /// </summary>
        /// <param name="bandId">The id of musical band profile</param>   
        [HttpGet("byBandId/{bandId}")]
        public async Task<ICollection<AlbumPreviewModel>> GetAlbumsByBandById(Guid bandId)
        {
            GetAlbumsByBandIdCommand request = new GetAlbumsByBandIdCommand() { BandId = bandId };

            return await _mediator.Send(request);
        }

        /// <summary>
        /// Creates a new musical album record, or updates existing one
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///	    "entityId": "b6dbf49d-95f3-4239-bef8-2bf8c986d696",
        ///     "title": "Reality",
        ///     "description": "Bowie in 2003 was more modest but still sharp. There's no concept or grand design here, just a bunch of good songs, including Jonathan Richman's snotty name-dropper “Pablo Picasso” and George Harrison’s spiritual “Try Some, Buy Some.” Bowie's at his best on spiky, menacing rockers like \"New Killer Star,\" which has enough hooks for three songs. This mostly upbeat album ends with a left turn, \"Bring Me the Disco King,\" where brushed drums and film-noir piano strand you in a dark part of town.",
        ///     "url": "http://bandcamp.com",
        ///     "startRecordDate": "2002-12-01T16:00:00",
        ///     "releaseDate": "2003-12-30T22:00:00",
        ///     "bandId": "71f08087-d04a-4007-ecfd-08d80d2e91ad",
        ///     "songs":[
        ///     	{
        ///     		"title": "Pablo Picasso",
        ///     		"order": 1
        ///     	},
        ///     	{
        ///     		"title": "New killer star",
        ///     		"order": 2
        ///     	}
        ///     	]
        ///     }
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>      
        [ProducesResponseType(typeof(AlbumViewModel), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<AlbumViewModel> UpsertAlbum(UpsertAlbumCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}