namespace WebApiGonBust.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this WebApplicationBuilder builder)
        {
            DbInstaller.InstallServices(builder.Services, builder.Configuration);
            MvcInstaller.InstallServices(builder.Services, builder.Configuration);
        }
    }
}
