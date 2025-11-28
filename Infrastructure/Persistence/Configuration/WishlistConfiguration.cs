using Domain.Entity;
using Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    internal class WishlistConfiguration : BaseEntityConfiguration<Wishlist>
    {
        protected override void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            // Force EF to map the foreign key to the ApplicationUser [AspNetUsers] table.
            // This is because I have separated the User (domain) and AppUser (IdentityUser for EF)
            builder.HasOne<ApplicationUser>()
                   .WithMany(u => u.Wishlists)
                   .HasForeignKey(w => w.CreatorId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
