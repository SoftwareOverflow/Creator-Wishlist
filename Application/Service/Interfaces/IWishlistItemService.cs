using Shared.DTO.Wishlist.Dtos;
using Shared.DTO.WishlistItem.Commands;

namespace Application.Service.Interfaces
{
    public interface IWishlistItemService
    {
        Task<WishlistItemDto> CreateWishlistItem(CreateWishlistItemCommand command);

        Task<WishlistItemDto> UpdateWishlistItem(UpdateWishlistItemCommand command);
    }
}
