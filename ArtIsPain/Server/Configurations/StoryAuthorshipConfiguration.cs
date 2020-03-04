using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtIsPain.Server.Configurations
{
    public class StoryAuthorshipConfiguration : IEntityTypeConfiguration<StoryAuthorship>
    {
        public void Configure(EntityTypeBuilder<StoryAuthorship> builder)
        {
            builder.HasKey(x => new { x.EntityId, x.AuthorId });

            builder.HasOne(x => x.Story)
                    .WithMany(x => x.StoryAuthorships)
                    .HasForeignKey(x => x.EntityId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Author)
                    .WithMany(x => x.StoryAuthorships)
                    .HasForeignKey(x => x.AuthorId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}