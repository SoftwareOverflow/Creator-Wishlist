using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.WishlistItem.Commands
{
    public record class UpdateWishlistItemCommand : WishlistItemBaseCommand
    {
        /// <summary>
        /// The unique identifier for the WishlistItem to be updated
        /// </summary>
        [Required]
        public Guid Guid{ get; set; }
    }
}
