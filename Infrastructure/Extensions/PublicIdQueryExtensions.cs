using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions
{
    internal static class PublicIdQueryExtensions
    {
        public static Task<T?> GetByPublicIdAsync<T>(this IQueryable<T> query, Guid guid) where T : BaseEntity
        {
            return query.SingleOrDefaultAsync(e => e.Guid == guid);
        }
    }
}
