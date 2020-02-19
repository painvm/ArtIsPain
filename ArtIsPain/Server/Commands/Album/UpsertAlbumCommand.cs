﻿using ArtIsPain.Server.Dtos.Album;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Commands.Album
{
    public class UpsertAlbumCommand : IUpsertEntityCommand<AlbumResult>
    {
        public Guid? EntityId { get; set; }

        public Guid BandId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public DateTime? StartRecordDate { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}