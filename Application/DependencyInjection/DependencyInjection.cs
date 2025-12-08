using Application.Service;
using Application.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IWishlistService, WishlistService>();
            services.AddScoped<IWishlistItemService, WishlistItemService>();

            return services;
        }
    }
}
