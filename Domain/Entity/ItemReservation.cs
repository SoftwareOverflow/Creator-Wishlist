namespace Domain.Entity
{
    public class ItemReservation : BaseEntity
    {
        // The ID of the reserved item
        public int ItemId { get; set; }

        // The ID of the user who reserved the item
        public int UserId { get; set; }

        // The timestamp when the reservation was made
        public DateTime ReservedAt { get; set; }

        // The timestamp when the reservation expires
        public DateTime ExpiresAt { get; set; }

        public WishlistItem Item { get; set; }

        public User Reserver { get; set; }
    }
}
