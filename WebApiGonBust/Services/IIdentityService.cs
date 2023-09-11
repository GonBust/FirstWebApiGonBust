using WebApiGonBust.Domain;

namespace WebApiGonBust.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> LoginAsync(string email, string password);

        Task<AuthenticationResult> ResgisterAsync(string email, string password);

        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}