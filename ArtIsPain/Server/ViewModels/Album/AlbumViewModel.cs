﻿using ArtIsPain.Server.ViewModels.Band;
using Server.ViewModels.Album.Song;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Server.ViewModels.Album
{
    public class AlbumViewModel : IViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public DateTime? StartRecordDate { get; set; }

        public DateTime ReleaseDate { get; set; }

        public BandPreviewModel Band { get; set; }

        public ICollection<SongPreviewModel> Songs { get; set; }
    }
}