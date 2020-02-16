using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtIsPain.Server.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasOne(x => x.Album)
                    .WithMany()
                    .HasForeignKey(x => x.VolumeId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.VolumeId)
                    .IsRequired(false);
        }
    }
}