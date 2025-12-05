using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.Wishlist.Dtos
{
    public record WishlistDetailsDto
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public string Title { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public IEnumerable<WishlistItemDto> Items { get; set; } = [];
    }
}
