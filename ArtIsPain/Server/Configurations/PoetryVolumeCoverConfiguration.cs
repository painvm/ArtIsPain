using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtIsPain.Server.Configurations
{
    public class PoetryVolumeCoverConfiguration : IEntityTypeConfiguration<PoetryVolumeCover>
    {
        public void Configure(EntityTypeBuilder<PoetryVolumeCover> builder)
        {
            builder.HasOne(x => x.PoetryVolume)
                    .WithMany()
                    .HasForeignKey(x => x.ObjectId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.ObjectId)
                    .IsRequired(false);
        }
    }
}