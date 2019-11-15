using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class MusicalAlbum : VolumeEntity, IObjectTypeWithImage, IAuthorized
    {
        public string Url { get; set; }
        public Guid ImageId { get; set; }
        public ICollection<Song> Songs { get; set; }
        public Guid AuthorId { get; set; }
    }
}