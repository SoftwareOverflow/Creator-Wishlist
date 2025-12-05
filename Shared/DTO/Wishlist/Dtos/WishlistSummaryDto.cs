namespace Shared.DTO.Wishlist.Dtos
{
    public record WishlistSummaryDto
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ItemsCount { get; set; }
    }
}
