using Domain.Entity;

namespace Application.Repository
{
    public interface IBaseEntityRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Retrieves the internal integer ID for a Wishlist using its public Guid.
        /// </summary>
        Task<int> GetInternalIdByPublicIdAsync(Guid publicId);

        Task AddAsync(T entity);

        Task<T?> GetByIdAsync(int id);

        Task UpdateAsync(T entiity);

        Task DeleteAsync(T entity);
    }
}
