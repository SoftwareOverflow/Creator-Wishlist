using Application.Repository;
using Domain.Entity;

namespace Infrastructure.Persistence.Repository
{
    internal class WishlistItemRepository : GenericEntityRepository<WishlistItem>, IWishlistItemRepository
    {
        private readonly AppDbContext _context;

        public WishlistItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
