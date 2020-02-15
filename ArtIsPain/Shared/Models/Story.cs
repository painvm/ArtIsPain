using ArtIsPain.Shared.Interfaces;
using ArtIsPain.Shared.Models;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Shared
{
    public class Story : Text, IEntityWithImage, IDescribable, IAuthorized
    {
        public Guid? ImageId { get; set; }

        public string Description { get; set; }

        public Guid AuthorId { get; set; }

        public ICollection<StoryAuthorship> StoryAuthorships { get; set; }
    }
}