using Domain.Entity;

namespace Application.Repository
{
    public interface IBaseEntityRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Retrieves the internal integer ID for the entity using its public Guid.
        /// </summary>
        Task<int?> GetInternalIdByPublicIdAsync(Guid publicId);

        Task<T> AddAsync(T entity);

        Task<T?> GetByIdAsync(int id);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
