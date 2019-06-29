using System.Collections.Generic;
using System.Linq;
using AuthenticationApi.Models;
using AuthenticationApi.Models.DbModels;

namespace AuthenticationApi.Services
{
    public class UserService : IUserService
    {
        private IEnumerable<User> _localUsers = new[]
        {
            new User
            {
                FirstName = "John",
                LastName = "Pierce",
                Email = "john.pierce@gmail.com",
                Password = "test123",
                Username = "regularUser",
                RoleId = 2
            },
            new User
            {
                FirstName = "John",
                LastName = "Pierce",
                Email = "john.pierce@gmail.com",
                Password = "test123",
                Username = "moderatorUser",
                RoleId = 2
            },
            new User
            {
                FirstName = "John",
                LastName = "Pierce",
                Email = "john.pierce@gmail.com",
                Password = "test123",
                Username = "adminUser",
                RoleId = 3
            },
        };

        public UserModel GetUser(string username, string password)
        {
            var user = _localUsers.SingleOrDefault(u => u.Username == username && u.Password == password);

            if(user != null)
                return new UserModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Role = (UserRole)user.RoleId
                };

            return null;
        }
    }
}
