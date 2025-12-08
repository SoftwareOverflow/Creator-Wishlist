using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.Wishlist.Commands
{
    public record class CreateWishlistCommand
    {
        /// <summary>
        /// Title of the wishlist
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }


        /// <summary>
        /// Optional description for the wishlist
        /// </summary>
        public string? Description { get; set; }
    }
}
