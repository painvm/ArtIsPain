using ArtIsPain.Server.ViewModels;
using System;

namespace Server.ViewModels.Album.Song
{
    public class SongPreviewModel : IViewModel
    {
        public Guid Id { get; set; }

        public Guid AlbumId { get; set; }

        public string Title { get; set; }

        public int Order { get; set; }

        public TimeSpan Length { get; set; }
    }
}