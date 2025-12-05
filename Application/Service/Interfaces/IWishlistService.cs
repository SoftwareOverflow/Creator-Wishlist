using Shared.DTO.Wishlist.Commands;
using Shared.DTO.Wishlist.Dtos;
using Shared.DTO.Wishlist.Queries;

namespace Application.Service.Interfaces
{
    public interface IWishlistService
    {
        Task<Guid> CreateWishlistAsync(CreateWishlistCommand command);

        Task<IReadOnlyList<WishlistSummaryDto>> GetWishlistsForUser(WishlistsForUserQuery query);

        Task<WishlistDetailsDto> GetWishlistDetailsForUser(Guid id);

        Task<WishlistDetailsDto> GetWishlistDetails(Guid id);
    }
}
