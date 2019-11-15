using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class PhotoAlbum : VolumeEntity, IObjectTypeWithImage, IAuthorized
    {
        public Guid ImageId { get; set; }
        public Guid AuthorId  {get; set; }
}
}