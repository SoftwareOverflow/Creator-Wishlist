using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class WishlistItem : BaseEntity
    {
        /// <summary>
        /// [Required] Name of the item
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Item description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Url link to the item
        /// </summary>
        [Url]
        public string? ItemUrl { get; set; }

        /// <summary>
        /// Url of the item image
        /// </summary>
        [Url]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Foreign Key property to the wishlist this item belongs to
        /// </summary>
        public int WishlistId { get; set; }
    }
}
