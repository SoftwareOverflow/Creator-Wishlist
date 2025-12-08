using Application.Repository;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    internal class WishlistRepository : GenericEntityRepository<Wishlist>, IWishlistRepository
    {
        private readonly AppDbContext _context;

        public WishlistRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Wishlist?> GetByIdAsync(int id)
        {
            // We need the items with the Wishlist, override the generic repo
            return await _context.Wishlists.Where(x => x.Id == id).Include(w => w.Items).SingleOrDefaultAsync();
        }

        // TODO check that update will NOT remove all the items

        public Task<IEnumerable<Wishlist>> GetWishlistsForUser(int userId)
        {
            return Task.FromResult(
                _context.Wishlists.Where(w => w.UserId == userId).Include(w => w.Items).AsEnumerable());
        }
    }
}
