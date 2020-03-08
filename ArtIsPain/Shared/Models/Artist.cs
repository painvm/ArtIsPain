using ArtIsPain.Shared.Interfaces;
using System;

namespace ArtIsPain.Shared.Models
{
    public abstract class Artist : Person, ITitled
    {
        public DateTime StartActivityDate { get; set; }

        public DateTime? EndActivityDate { get; set; }

        public string Title { get; set; }
    }
}