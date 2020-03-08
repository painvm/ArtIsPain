using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Shared;
using ArtIsPain.Shared.Interfaces;
using ArtIsPain.Shared.Models;
using Bogus;
using System.Linq;

namespace ArtIsPain.Server.Data.Seed
{
    public class SongBuilder : ISeedDataBuilder
    {
        public IQueryable<IEntity> CreateSeedData()
        {
            Faker<Song> bandFaker = new Faker<Song>();

            int trackOrder = 0;

            bandFaker
                .StrictMode(false)
                .RuleFor(b => b.Id, f => f.Random.Uuid())
                .RuleFor(b => b.Title, f => f.Random.Words(2))
                .RuleFor(b => b.Order, f => trackOrder > 13 ? trackOrder - 13 : ++trackOrder);

            Faker<Song> bandLogoFaker = new Faker<Song>();

            return bandFaker.Generate(1024).AsQueryable();
        }
    }
}