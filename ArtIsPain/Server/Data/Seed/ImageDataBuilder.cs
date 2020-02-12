using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Seed
{
    public class ImageDataBuilder : ISeedDataBuilder<Image>
    {
        public ICollection<Image> CreateSeedData()
        {
            throw new NotImplementedException();
        }
    }
}
