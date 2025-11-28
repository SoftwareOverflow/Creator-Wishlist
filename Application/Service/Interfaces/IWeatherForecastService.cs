using Shared.DTO;

namespace Application.Service.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetWeatherForecasts();
    }
}
