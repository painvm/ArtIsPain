using ArtIsPain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtIsPain.Server.Configurations
{
    public class PoetryVolumeConfiguration : IEntityTypeConfiguration<PoetryVolume>
    {
        public void Configure(EntityTypeBuilder<PoetryVolume> builder)
        {
        }
    }
}
