using System;
using System.Collections.Generic;
using System.Text;
using AuthenticationApi.Models;
using AuthenticationApi.Services;

namespace AuthenticationApi.Tests
{
    public class UserServiceMock : IUserService
    {
        public UserModel GetUser(string username, string password)
        {
            if (username == "john" && password == "testASDF")
                return new UserModel
                {
                    FirstName = "John",
                    LastName = "Pierce"
                };

            return null;
        }
    }
}
