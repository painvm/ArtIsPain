using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class SoloArtist : HumanBeingEntity, IAuthor
    {
        public DateTime StartActivityDate { get; set; }

        public DateTime? EndActivityDate { get; set; }

        public bool IsDead { get; set; }
    }
}