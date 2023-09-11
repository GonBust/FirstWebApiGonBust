using Microsoft.EntityFrameworkCore;
using WebApiGonBust.Data;
using WebApiGonBust.Domain;

namespace WebApiGonBust.Services
{
    public class ForecastService : IForecastService
    {
        private readonly DataContext _dataContext;

        public ForecastService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<WeatherForecast>> GetForecastsAsync()
        {
            return await _dataContext.Forecasts.ToListAsync();
        }

        public async Task<WeatherForecast> GetForecastByIdAsync(Guid forecastId)
        {
            return await _dataContext.Forecasts.SingleOrDefaultAsync(x => x.Id == forecastId);
        }

        public async Task<bool> CreateForecastAsync(WeatherForecast forecast)
        {
            await _dataContext.Forecasts.AddAsync(forecast);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateForecastAsync(WeatherForecast forecastToUpdate)
        {
            _dataContext.Forecasts.Update(forecastToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteForecastAsync(Guid forecastId)
        {
            var forecast =  await GetForecastByIdAsync(forecastId);

            if (forecast == null)
                return false;

            _dataContext.Forecasts.Remove(forecast);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> UserOwnsForecastAsync(Guid forecastId, string userId)
        {
            var forecast = await _dataContext.Forecasts.AsNoTracking().SingleOrDefaultAsync(x => x.Id == forecastId);

            if (forecast == null)
                return false;

            if (forecast.UserId != userId)
                return false;

            return true;
        }
    }
}
