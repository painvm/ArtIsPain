using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtIsPain.Server.Configurations
{
    public class MusicalAlbumConfiguration : IEntityTypeConfiguration<MusicalAlbum>
    {
        public void Configure(EntityTypeBuilder<MusicalAlbum> builder)
        {
            builder.HasOne(x => x.Image)
                    .WithMany()
                    .HasForeignKey(x => x.ImageId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.ImageId)
                    .IsRequired(false);
        }
    }
}