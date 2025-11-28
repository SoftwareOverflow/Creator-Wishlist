using Application.Repository;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly AppDbContext _context;

        public WishlistRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Wishlist entity)
        {
            _context.Wishlists.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Wishlist entity)
        {
            _context.Wishlists.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Wishlist?> GetByIdAsync(int id)
        {
            return await _context.Wishlists.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<int> GetInternalIdByPublicIdAsync(Guid publicId)
        {
            var wishlist = await _context.Wishlists.SingleAsync(w => w.Guid == publicId);
            return wishlist.Id;
        }

        public async Task UpdateAsync(Wishlist entiity)
        {
            _context.Wishlists.Update(entiity);
            await _context.SaveChangesAsync();
        }

        public Task AddItemAsync(WishlistItem item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemAsync(WishlistItem item)
        {
            throw new NotImplementedException();
        }

        public Task<WishlistItem?> GetItemById(int id, int wishlistId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemAsync(WishlistItem item)
        {
            throw new NotImplementedException();
        }
    }
}
