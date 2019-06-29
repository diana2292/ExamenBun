using AuthenticationApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AuthenticationApi.Tests
{
    


    [TestClass]
    public class UserServiceTest
    {
        private readonly IUserService _userService;

        public UserServiceTest()
        {
            _userService = new UserServiceMock();
        }

        [TestMethod]
        public void TestUserExist()
        {
            var user = _userService.GetUser("john", "testASDF");

            Assert.IsNotNull(user);
            Assert.AreEqual(user.FirstName, "John");
        }

        [TestMethod]
        public void TestUserWrongUsername()
        {
            var user = _userService.GetUser("john1", "testASDF");

            Assert.IsNull(user);
        }

        [TestMethod]
        public void TestUserWrongPassword()
        {
            var user = _userService.GetUser("john", "testASDFE");

            Assert.IsNull(user);
        }

        [TestMethod]
        public void TestUserWrongCredentials()
        {
            var user = _userService.GetUser("john1", "testASDFE");

            Assert.IsNull(user);
        }
    }
}
