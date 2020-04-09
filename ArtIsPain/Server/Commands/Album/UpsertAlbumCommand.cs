using ArtIsPain.Server.ViewModels.Album;
using Server.Commands.Album;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Server.Commands.Album
{
    public class UpsertAlbumCommand : IUpsertEntityCommand<AlbumViewModel>
    {
        public Guid? EntityId { get; set; }

        public Guid BandId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public DateTime? StartRecordDate { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<UpsertSongCommand> Songs { get; set; }
    }
}