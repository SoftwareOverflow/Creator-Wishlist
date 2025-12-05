namespace Domain.Entity
{
    public interface IBelongToUser
    {
        /// <summary>
        /// Id of the user for which this entity belongs
        /// </summary>
        int UserId { get; set; }
    }
}
