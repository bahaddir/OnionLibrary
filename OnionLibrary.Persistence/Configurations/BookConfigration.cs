using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnionLibrary.Persistence.Configurations
{
    public class BookConfigration : BaseConfigration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            base.Configure(builder);
            builder.HasOne(b => b.Author)
                   .WithMany(a => a.Books)
                   .HasForeignKey(b => b.AuthorId);
            builder.HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);




        }

    }

}
