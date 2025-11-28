using Application.Service.Interfaces;
using Shared.DTO;
using System.Net.Http.Json;

namespace WebApp.Client.Services
{
    public class ClientWeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _http;

        public ClientWeatherForecastService(HttpClient http)
        {
            _http = http;
        }

        public async Task<WeatherForecast[]> GetWeatherForecasts()
        {
            Console.WriteLine("CLIENT SIDE weather forecast");

            return await _http.GetFromJsonAsync<WeatherForecast[]>("api/WeatherForecast");
        }
    }
}
