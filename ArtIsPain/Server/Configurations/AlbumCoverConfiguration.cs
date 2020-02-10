using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Configurations
{
    public class AlbumCoverConfiguration : IEntityTypeConfiguration<AlbumCover>
    {
        public void Configure(EntityTypeBuilder<AlbumCover> builder)
        {
            builder.HasOne(x => x.Album)
                    .WithMany()
                    .HasForeignKey(x => x.ObjectId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
