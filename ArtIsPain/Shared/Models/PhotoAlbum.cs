using System;

namespace ArtIsPain.Shared.Models
{
    public class PhotoAlbum : Volume, IAuthorized
    {
        public Guid AuthorId { get; set; }
    }
}