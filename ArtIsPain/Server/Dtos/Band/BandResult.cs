﻿using ArtIsPain.Server.Dtos.Album;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Server.Dtos.Band
{
    public class BandResult : IResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime FormationDate { get; set; }

        public DateTime? DisbandDate { get; set; }

        public ICollection<AlbumPreview> Albums { get; set; }
    }
}