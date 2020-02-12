using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Interfaces
{
    interface ISeedDataBuilder<T>
    {
        ICollection<T> CreateSeedData();
    }
}
