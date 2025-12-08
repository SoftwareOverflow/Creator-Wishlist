namespace Shared.DTO.Wishlist.Dtos
{
    public record class WishlistItemDto
    {
        public Guid Guid { get; set; }

        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        public string? ItemUrl { get; set; }

        public string? ImageUrl { get; set; }
    }
}
