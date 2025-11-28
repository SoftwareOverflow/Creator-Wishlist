using Shared.DTO.Wishlist;

namespace Application.Service.Interfaces
{
    public interface IWishlistService
    {
        Task<Guid> CreateWishlistAsync(CreateWishlistCommand command);
    }
}
