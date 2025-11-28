namespace Domain.Entity
{
    public class WishlistItem : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }


        public int WishlistId { get; set; }
    }
}
