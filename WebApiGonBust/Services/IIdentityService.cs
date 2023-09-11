using WebApiGonBust.Domain;

namespace WebApiGonBust.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> ResgisterAsync(string email, string password);
    }
}