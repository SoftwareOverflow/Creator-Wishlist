using Domain.Entity;

namespace Application.Repository
{
    public interface IWishlistRepository : IBaseEntityRepository<Wishlist>
    {
        Task<IEnumerable<Wishlist>> GetWishlistsForUser(int userId);
    }
}
