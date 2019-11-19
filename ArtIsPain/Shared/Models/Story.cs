using ArtIsPain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class Story : Text, IEntityWithImage, IDescribable, IAuthorized
    {
        public Guid ImageId { get; set; }

        public string Description { get; set; }

        public Guid AuthorId { get; set; }
    }
}