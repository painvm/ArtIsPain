using ArtIsPain.Shared.Interfaces;
using System;


namespace ArtIsPain.Shared.Models
{
    public abstract class Artist : Person, ITitled
    {
        public DateTimeOffset StartActivityDate { get; set; }

        public DateTimeOffset? EndActivityDate { get; set; }

        public string Title { get; set; }

    }
}