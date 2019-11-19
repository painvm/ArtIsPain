using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class PoetryVolume : Volume, IAuthorized
    {
        public Guid AuthorId { get; set; }
    }
}