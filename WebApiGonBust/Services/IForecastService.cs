using WebApiGonBust.Domain;
using static WebApiGonBust.Contracts.V1.ApiRoutes;

namespace WebApiGonBust.Services
{
    public interface IForecastService
    {
        Task<List<WeatherForecast>> GetForecastsAsync();

        Task<WeatherForecast> GetForecastByIdAsync(Guid forecastId);

        Task<bool> CreateForecastAsync(WeatherForecast forecast);

        Task<bool> UpdateForecastAsync(WeatherForecast forecastToUpdate);

        Task<bool> DeleteForecastAsync(Guid forecastId);

        Task<bool> UserOwnsForecastAsync(Guid forecastId, string userId);
    }
}
