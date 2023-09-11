using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApiGonBust.Data;
using WebApiGonBust.Services;

namespace WebApiGonBust.Installers
{
    public static class DbInstaller
    {
        public static void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IForecastService, ForecastService>();
        }
    }
}
