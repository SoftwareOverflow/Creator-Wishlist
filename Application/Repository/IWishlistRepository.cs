using Domain.Entity;

namespace Application.Repository
{
    public interface IWishlistRepository : IBaseEntityRepository<Wishlist>
    {
        Task AddItemAsync(WishlistItem item);

        Task UpdateItemAsync(WishlistItem item);

        Task<WishlistItem?> GetItemById(int id, int wishlistId);

        Task DeleteItemAsync(WishlistItem item);

        Task<IEnumerable<Wishlist>> GetWishlistsForUser(int userId);
    }
}
