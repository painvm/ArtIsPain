using System;

namespace ArtIsPain.Shared
{
    public class PhotoAlbum : Volume, IAuthorized
    {
        public Guid AuthorId { get; set; }
    }
}