using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.WishlistItem.Commands
{
    public abstract record class WishlistItemBaseCommand
    {
        /// <summary>
        /// Name of the wishlist item
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }


        /// <summary>
        /// Optional description for the wishlist item
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Optional URL link to the item
        /// </summary>
        [Url]
        public string ItemUrl { get; set; }

        /// <summary>
        /// Optional image url for the item.
        /// </summary>
        [Url]
        public string ImageUrl { get; set; }

        /// <summary>
        /// The guid for the Wishlist this item belongs to
        /// </summary>
        public Guid WishlistGuid { get; set;  }
    }
}
