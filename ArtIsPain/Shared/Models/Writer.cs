using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class Writer : HumanBeingEntity, IAuthor
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsDead { get; set; }

        public DateTime StartActivityDate { get; set; }

        public DateTime? EndActivityDate { get; set; }
    }
}