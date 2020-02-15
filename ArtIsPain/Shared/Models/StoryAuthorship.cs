﻿using System;

namespace ArtIsPain.Shared.Models
{
    public class StoryAuthorship
    {
        public Guid StoryId { get; set; }

        public Guid AuthorId { get; set; }

        public Story Story { get; set; }

        public Writer Author { get; set; }
    }
}