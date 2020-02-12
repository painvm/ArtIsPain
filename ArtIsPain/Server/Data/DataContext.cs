using ArtIsPain.Server.Configurations;
using ArtIsPain.Shared;
using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ArtIsPain.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<BandLogo> BandLogos { get; set; }
        public DbSet<MusicalAlbum> MusicalAlbums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<PoetryVolumeAuthorship> PoetryVolumeAuthorships { get; set; }
        public DbSet<StoryAuthorship> StoryAuthorships { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Band>(new BandConfiguration());
            modelBuilder.ApplyConfiguration<BandLogo>(new BandLogoConfiguration());
            modelBuilder.ApplyConfiguration<Image>(new ImageConfiguration());
            modelBuilder.ApplyConfiguration<AlbumCover>(new AlbumCoverConfiguration());
            modelBuilder.ApplyConfiguration<Song>(new SongConfiguration());
            modelBuilder.ApplyConfiguration<PoetryVolumeAuthorship>(new PoetryVolumeAuthorshipConfiguration());
            modelBuilder.ApplyConfiguration<StoryAuthorship>(new StoryAuthorshipConfiguration());
        }
    }
}

