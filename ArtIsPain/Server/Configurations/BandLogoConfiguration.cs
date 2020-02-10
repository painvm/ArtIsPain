using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtIsPain.Server.Configurations
{
    public class BandLogoConfiguration : IEntityTypeConfiguration<BandLogo>
    {
        public void Configure(EntityTypeBuilder<BandLogo> builder)
        {
            builder.HasOne(x => x.Band)
                    .WithMany()
                    .HasForeignKey(x => x.ObjectId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
