using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public abstract class Artist : Person, ITitled
    {
        public DateTime StartActivityDate { get; set; }

        public DateTime? EndActivityDate { get; set; }

        public string Title { get; set; }
    }
}