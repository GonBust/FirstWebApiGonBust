using WebApiGonBust.Data;
using WebApiGonBust.Services;

namespace WebApiGonBust.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DataContext>();

            builder.Services.AddScoped<IForecastService, ForecastService>();
        }
    }
}
