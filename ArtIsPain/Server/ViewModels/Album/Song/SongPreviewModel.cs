using ArtIsPain.Server.ViewModels;
using System;

namespace Server.ViewModels.Album.Song
{
    public class SongPreviewModel : IViewModel
    {
        public Guid Id { get; set; }

        public Guid AlbumId { get; set; }

        /// <example>Pablo Picasso</example>
        public string Title { get; set; }

        /// <example>1</example>
        public int Order { get; set; }

        /// <example>03:45:00</example>
        public TimeSpan Length { get; set; }
    }
}