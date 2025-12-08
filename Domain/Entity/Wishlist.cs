using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Wishlist : BaseEntity, IBelongToUser
    {
        /// <summary>
        /// Title for the wishlist
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Optional description of the wishlist
        /// </summary>
        public string? Description { get; set; }


        /// <summary>
        /// Identifier of the user who created the wishlist
        /// </summary>
        public int UserId { get; set; }

        // public User Creator { get; set; } I HAD TO REMOVE THIS TO GET THE APPLICATIONUSER MAPPING TO WORK.
        public List<WishlistItem> Items { get; set; } = [];
    }
}
