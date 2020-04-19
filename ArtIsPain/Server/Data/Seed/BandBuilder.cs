using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Shared.Interfaces;
using ArtIsPain.Shared.Models;
using Bogus;
using System.Linq;

namespace ArtIsPain.Server.Data.Seed
{
    public class BandBuilder : ISeedDataBuilder
    {
        public IQueryable<IEntity> CreateSeedData()
        {
            Faker<Band> bandFaker = new Faker<Band>();

            bandFaker
                .StrictMode(false)
                .RuleFor(b => b.Id, f => f.Random.Uuid())
                .RuleFor(b => b.Title, f => f.Random.Words(3));

            Faker<BandLogo> bandLogoFaker = new Faker<BandLogo>();

            return bandFaker.Generate(50).AsQueryable();
        }
    }
}