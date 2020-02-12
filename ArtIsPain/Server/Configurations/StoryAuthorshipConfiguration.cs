using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Configurations
{
    public class StoryAuthorshipConfiguration : IEntityTypeConfiguration<StoryAuthorship>
    {
        public void Configure(EntityTypeBuilder<StoryAuthorship> builder)
        {
            builder.HasKey(x => new { x.StoryId, x.AuthorId });

            builder.HasOne(x => x.Story)
                    .WithMany(x => x.StoryAuthorships)
                    .HasForeignKey(x => x.StoryId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Author)
                    .WithMany(x => x.StoryAuthorships)
                    .HasForeignKey(x => x.AuthorId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
