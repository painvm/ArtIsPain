using ArtIsPain.Shared;
using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasDiscriminator<string>("ImageType")
                    .HasValue<BandLogo>("BandLogo")
                    .HasValue<AlbumCover>("AlbumCover");
        }
    }
}
