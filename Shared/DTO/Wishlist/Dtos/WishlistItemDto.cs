namespace Shared.DTO.Wishlist.Dtos
{
    public record class WishlistItemDto
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string IamgeUrl { get; set; }
    }
}
