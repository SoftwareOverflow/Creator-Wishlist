using Domain.Entity;

namespace Application.Repository
{
    public interface IUserRepository
    {
        Task<int> GetInternalIdFromPublicIdAsync(Guid id);

        Task<User> GetByIdAsync(int id);

        Task<int> GetCurrentUserId();
    }
}
