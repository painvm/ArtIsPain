using ArtIsPain.Shared.Interfaces;
using System;

namespace ArtIsPain.Shared.Models
{
    public class StoryAuthorship : IMultiAuthorized
    {
        public Guid EntityId { get; set; }

        public Guid? AuthorId { get; set; }

        public Story Story { get; set; }

        public Writer Author { get; set; }
    }
}