using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;

namespace ArtIsPain.Server.Data
{
    public class DataContext : DbContext
    {
        private readonly IEnumerable<ISeedDataBuilder> _seedDataBuilders;

        public DataContext(DbContextOptions<DataContext> options,
            IEnumerable<ISeedDataBuilder> seedDataBuilders) : base(options)
        {
            _seedDataBuilders = seedDataBuilders;
        }

        #region DbSets

        public virtual DbSet<Band> Bands { get; set; }

        public DbSet<Poetry> Poetries { get; set; }

        public DbSet<BandLogo> BandLogos { get; set; }

        public DbSet<MusicalAlbum> MusicalAlbums { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<PoetryVolumeAuthorship>
            PoetryVolumeAuthorships { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<StoryAuthorship> StoryAuthorships { get; set; }

        #endregion DbSets

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());

            foreach (var dataBuilder in _seedDataBuilders)
            {
                var data = dataBuilder.CreateSeedData();

                modelBuilder.Entity(data.ElementType).HasData(data);
            }

            modelBuilder.Entity<Artist>().Property(p => p.StartActivityDate)
                .HasColumnType("date");
            modelBuilder.Entity<Artist>().Property(p => p.EndActivityDate)
                .HasColumnType("date");
        }
    }
}