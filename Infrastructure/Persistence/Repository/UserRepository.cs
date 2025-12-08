using Application.Repository;
using Application.Service.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public UserRepository(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public Task<int> GetCurrentUserId()
        {
            var userId = _currentUserService.UserId;

            if(userId == null)
            {
                // TODO errors, logging etc
                throw new UnauthorizedAccessException("Unable to find a logged in user.");
            } else
            {
                return Task.FromResult(userId.Value);
            }
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
