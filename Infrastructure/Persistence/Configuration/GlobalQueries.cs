using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Configuration
{
    internal static class GlobalQueries
    {
        public static ModelBuilder FilterForCurrentUser(this ModelBuilder builder, int internalUserId)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                // Check if the entity implements the IBelongToUser interface
                if (typeof(IBelongToUser).IsAssignableFrom(entityType.ClrType))
                {
                    // Create a parameter for the lambda expression (e.g., 'e' => ...)
                    var parameter = Expression.Parameter(entityType.ClrType, "e");

                    // Create the property access expression (e.g., e.UserId)
                    var property = Expression.Property(parameter, nameof(IBelongToUser.UserId));

                    // Create the constant expression for the current user's ID
                    var constant = Expression.Constant(internalUserId);

                    // Create the binary comparison expression (e.g., e.ApplicationUserId == internalUserId)
                    var equal = Expression.Equal(property, constant);

                    // Create the final lambda expression
                    var lambda = Expression.Lambda(equal, parameter);

                    // Apply the query filter to the entity
                    entityType.SetQueryFilter(lambda);
                }
            }

            return builder;
        }
    }
}
