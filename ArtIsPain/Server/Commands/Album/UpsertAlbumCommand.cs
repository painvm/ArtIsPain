using ArtIsPain.Server.ViewModels.Album;
using System;

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
    }
}