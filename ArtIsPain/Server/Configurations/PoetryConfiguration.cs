using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtIsPain.Server.Configurations
{
    public class PoetryConfiguration : IEntityTypeConfiguration<Poetry>
    {
        public void Configure(EntityTypeBuilder<Poetry> builder)
        {
            builder.HasOne(x => x.PoetryVolume)
                    .WithMany()
                    .HasForeignKey(x => x.VolumeId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.VolumeId)
                    .IsRequired(false);
        }
    }
}