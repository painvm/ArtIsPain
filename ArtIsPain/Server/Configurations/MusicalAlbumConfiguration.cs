using ArtIsPain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        }
    }
}
