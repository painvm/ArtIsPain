using System;

namespace ArtIsPain.Shared
{
    public abstract class Artist : Person, ITitled
    {
        public DateTime StartActivityDate { get; set; }

        public DateTime? EndActivityDate { get; set; }

        public string Title { get; set; }
    }
}