using ArtIsPain.Server.ViewModels.Band;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.ViewModels.Album.Song;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Server.ViewModels.Album
{
    public class AlbumViewModel : IViewModel
    {
        public Guid Id { get; set; }

        /// <example>Reality</example>
        public string Title { get; set; }

        /// <example>Bowie in 2003 was more modest but still sharp. There's no concept or grand design here, just a bunch of good songs, including Jonathan Richman's snotty name-dropper “Pablo Picasso” and George Harrison’s spiritual “Try Some, Buy Some.” Bowie's at his best on spiky, menacing rockers like \"New Killer Star,\" which has enough hooks for three songs. This mostly upbeat album ends with a left turn, \"Bring Me the Disco King,\" where brushed drums and film-noir piano strand you in a dark part of town.</example>
        public string Description { get; set; }

        /// <example>http://bandcamp.com</example>
        public string Url { get; set; }

        /// <example>2002-12-01T16:00:00</example>
        public DateTime? StartRecordDate { get; set; }

        /// <example>2003-12-01T16:00:00</example>
        public DateTime ReleaseDate { get; set; }

        public BandPreviewModel Band { get; set; }

        public ICollection<SongPreviewModel> Songs { get; set; }
    }
}