using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public interface IAuthor
    {
        DateTime StartActivityDate { get; set; }

        DateTime? EndActivityDate { get; set; }

        bool IsDead { get; set; }
    }
}