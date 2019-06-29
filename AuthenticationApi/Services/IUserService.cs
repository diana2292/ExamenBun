using AuthenticationApi.Models;

namespace AuthenticationApi.Services
{
    public interface IUserService
    {
        UserModel GetUser(string username, string password);
    }
}