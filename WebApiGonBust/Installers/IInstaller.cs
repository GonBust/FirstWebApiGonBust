namespace WebApiGonBust.Installers
{
    public interface IInstaller
    {
        public void InstallServices(WebApplicationBuilder builder);
    }
}
