using AuthenticationApi.Models;

namespace AuthenticationApi.Authentication
{
    public interface IAuthenticateService
    {
        string Authenticate(UserLoginModel userLoginModel);
    }
}