using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Shared;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Seed
{
    public class BandBuilder : ISeedDataBuilder<Band>
    {
        public ICollection<Band> CreateSeedData()
        {
            Faker<Band> bandFaker = new Faker<Band>();

            bandFaker
                .StrictMode(true)
                .RuleFor(b => b.Id, f => f.Random.Uuid())
                .RuleFor(b => b.Title, f => f.Random.Words(3));

            return bandFaker.Generate(50).ToList();
        }
    }
}
