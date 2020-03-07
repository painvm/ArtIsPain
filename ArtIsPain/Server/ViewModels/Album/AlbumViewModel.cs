using System;

namespace ArtIsPain.Server.ViewModels.Album
{
    public class AlbumViewModel : IViewModel
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