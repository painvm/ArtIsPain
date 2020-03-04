using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtIsPain.Server.Configurations
{
    public class PoetryVolumeAuthorshipConfiguration : IEntityTypeConfiguration<PoetryVolumeAuthorship>
    {
        public void Configure(EntityTypeBuilder<PoetryVolumeAuthorship> builder)
        {
            builder.HasKey(x => new { x.EntityId, x.AuthorId });

            builder.HasOne(x => x.PoetryVolume)
                    .WithMany(x => x.PoetryVolumeAuthorships)
                    .HasForeignKey(x => x.EntityId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Author)
                    .WithMany(x => x.PoetryVolumeAuthorships)
                    .HasForeignKey(x => x.AuthorId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}