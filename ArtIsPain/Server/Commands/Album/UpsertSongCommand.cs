using System;
using ArtIsPain.Server.Commands;
using Server.ViewModels.Album.Song;

namespace Server.Commands.Album
{
    public class UpsertSongCommand : IUpsertEntityCommand<SongPreviewModel>
    {
        public Guid? EntityId { get; set; }

        public Guid AlbumId { get; set; }

        public string Title { get; set; }

        public int Order { get; set; }

        public TimeSpan Length { get; set; }
    }
}