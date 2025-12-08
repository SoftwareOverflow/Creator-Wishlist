using Application.Service.Interfaces;
using Domain.Entity;
using Infrastructure.Persistence.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        private readonly ICurrentUserService _currentUserService;

        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            builder.Entity<ApplicationUser>(builder =>
            {
                builder.HasIndex(x => x.Guid).IsUnique();
            });

/*            var currentUserGuid = _currentUserService.UserGuid;
            var internalUserId = Users.Where(u => u.Guid == currentUserGuid)
                .Select(u => u.Id)
                .FirstOrDefault();

            builder.FilterForCurrentUser(internalUserId);*/

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
