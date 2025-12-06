using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnionLibrary.Persistence.Configurations
{
    public class BookTagConfigration : BaseConfigration<BookTag>
    {
        public override void Configure(EntityTypeBuilder<BookTag> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => new { x.BookId, x.TagId }).IsUnique();
        }
    }

}
