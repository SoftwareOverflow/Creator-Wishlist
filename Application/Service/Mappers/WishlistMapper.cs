using Domain.Entity;
using Shared.DTO.Wishlist.Dtos;

namespace Application.Service.Mappers
{
    public static class WishlistMapper
    {
        public static IEnumerable<WishlistSummaryDto> ToSummaryDto(this IEnumerable<Wishlist> wishlists) =>
            wishlists.Select(w => w.ToSummaryDto());

        public static WishlistSummaryDto ToSummaryDto(this Wishlist wishlist) => new()
            {
                Guid = wishlist.Guid,
                Title = wishlist.Title,
                Description = wishlist.Description,
                ItemsCount = wishlist.Items.Count,
            };

        public static WishlistDetailsDto ToDetailsDto(this Wishlist wishlist) => new()
        {
            Guid = wishlist.Guid,
            Title = wishlist.Title,
            Description = wishlist.Description,
            Items = wishlist.Items.ToDto()
        };


        public static IEnumerable<WishlistItemDto> ToDto(this IEnumerable<WishlistItem> items) => items.Select(i => i.ToDto());

        public static WishlistItemDto ToDto(this WishlistItem item) => new()
        {
            Guid = item.Guid,
            Name = item.Name,
            Description = item.Description,
            ItemUrl = item.ItemUrl,
            ImageUrl = item.ImageUrl
        };
    }
}
