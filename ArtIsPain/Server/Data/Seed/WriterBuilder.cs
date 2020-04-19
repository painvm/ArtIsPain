using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Shared.Interfaces;
using ArtIsPain.Shared.Models;
using Bogus;
using System.Linq;

namespace ArtIsPain.Server.Data.Seed
{
    public class WriterBuilder : ISeedDataBuilder
    {
        public IQueryable<IEntity> CreateSeedData()
        {
            Faker<Writer> bandFaker = new Faker<Writer>();

            bandFaker
                .StrictMode(false)
                .RuleFor(b => b.Id, f => f.Random.Uuid())
                .RuleFor(b => b.Description, f => f.Random.Words(3))
                .RuleFor(b => b.Title, f => $"{f.Person.FirstName} {f.Person.LastName}")
                .RuleFor(b => b.StartActivityDate, f => f.Date.Past(20));

            return bandFaker.Generate(50).AsQueryable();
        }
    }
}