using Application.Repository;
using Application.Service;
using Application.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //builder.Services.AddScoped<WishlistService>();
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            return services;
        }
    }
}
