using Application.Repository;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public abstract class GenericEntityRepository<T> : IBaseEntityRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;
        private readonly AppDbContext _context;

        protected GenericEntityRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async virtual Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async virtual Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.SingleAsync(x => x.Id == id);
        }

        public async virtual Task<int?> GetInternalIdByPublicIdAsync(Guid publicId)
        {
            var entity = await _dbSet.SingleOrDefaultAsync(x => x.Guid == publicId);

            return entity?.Id;
        }

        public async virtual Task<T> UpdateAsync(T entity)
        {
            // TODO check how this will work if we're updating something with navigation properties (e.g. updating a Wishlist - do I need to ensure I have loaded all the WishlistItems first? Or will it delete those?)

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
