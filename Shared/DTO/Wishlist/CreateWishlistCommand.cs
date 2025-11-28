using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.Wishlist
{
    public class CreateWishlistCommand
    {
        /// <summary>
        /// Public Id of the Creator for the wishlist
        /// </summary>
        [Required]
        public Guid CreatorPublicId { get; set; }

        /// <summary>
        /// Title of the wishlist
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }


        /// <summary>
        /// Optional description for the wishlist
        /// </summary>
        public string Description { get; set; }
    }
}
