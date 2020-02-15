using ArtIsPain.Shared;
using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtIsPain.Server.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasDiscriminator<string>("ImageType")
                    .HasValue<BandLogo>("BandLogo")
                    .HasValue<AlbumCover>("AlbumCover")
                    .HasValue<PoetryVolumeCover>("PoetryVolumeCover")
                    .HasValue<PhotoObject>("Photo");
        }
    }
}