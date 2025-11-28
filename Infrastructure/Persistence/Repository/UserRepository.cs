using Application.Repository;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

            return new User()
            {
                Id = user.Id,
                Guid = user.Guid,
                IsCreator = user.IsCreator,
            };
        }

        public async Task<int> GetInternalIdFromPublicIdAsync(Guid id)
        {
            var user = await _context.Users.SingleAsync(u => u.Guid == id);
            return user.Id;
        }
    }
}
