namespace Domain.Entity
{
    public class BaseEntity
    {
        /// <summary>
        /// Internal database ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Public facing ID
        /// </summary>
        public Guid Guid { get; set; }
    }
}
