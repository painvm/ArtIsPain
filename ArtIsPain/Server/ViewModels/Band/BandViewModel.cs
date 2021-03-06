﻿using ArtIsPain.Server.ViewModels.Album;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Server.ViewModels.Band
{
    public class BandViewModel : IViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string FormationDate { get; set; }

        public string DisbandDate { get; set; }

        public ICollection<AlbumPreviewModel> Albums { get; set; }
    }
}