using ArtIsPain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasOne(x => x.Album)
                    .WithMany()
                    .HasForeignKey(x => x.VolumeId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
