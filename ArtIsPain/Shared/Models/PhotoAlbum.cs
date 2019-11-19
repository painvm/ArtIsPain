using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class PhotoAlbum : Volume, IAuthorized
    {
        public Guid AuthorId  {get; set; }
}
}