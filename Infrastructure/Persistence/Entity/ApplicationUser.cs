using Domain.Entity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence.Entity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public Guid Guid { get; set; } = Guid.NewGuid();

        public bool IsCreator { get; set; }

        public ICollection<Wishlist> Wishlists { get; set; } = [];
    }
}
