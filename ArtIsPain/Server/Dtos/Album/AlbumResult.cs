﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Dtos.Album
{
    public class AlbumResult : IResult
    {
        public Guid Id { get; set; }

        public string BandName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public DateTime? StartRecordDate { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}