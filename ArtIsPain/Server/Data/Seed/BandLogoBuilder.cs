using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Shared;
using ArtIsPain.Shared.Interfaces;
using ArtIsPain.Shared.Models;
using Bogus;
using System.Linq;

namespace ArtIsPain.Server.Data.Seed
{
    public class BandLogoBuilder : ISeedDataBuilder
    {
        public IQueryable<IEntity> CreateSeedData()
        {
            Faker<BandLogo> bandLogoFaker = new Faker<BandLogo>();

            bandLogoFaker
                .StrictMode(false)
                .RuleFor(b => b.Id, f => f.Random.Uuid());

            return bandLogoFaker.Generate(50).AsQueryable();
        }
    }
}