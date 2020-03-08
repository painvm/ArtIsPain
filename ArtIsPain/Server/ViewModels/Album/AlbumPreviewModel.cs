using ArtIsPain.Server.ViewModels.Band;
using System;

namespace ArtIsPain.Server.ViewModels.Album
{
    public class AlbumPreviewModel : IViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public BandPreviewModel Band { get; set; }
    }
}