using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiGonBust.Domain;

namespace WebApiGonBust.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> Forecasts { get; set; }

        public DbSet<Tags> Tags { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
