namespace Domain.Entity
{
    public class User : BaseEntity
    {
        public bool IsCreator { get; set; }

        public ICollection<Wishlist> Wishlists { get; set; } = [];
        //public List<ItemReservation> ItemReservations { get; set; }
    }
}
