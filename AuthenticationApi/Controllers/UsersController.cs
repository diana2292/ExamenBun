using System.Collections.Generic;
using System.Linq;
using AuthenticationApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public IEnumerable<UserModel> GetAllUsers()
        {
            return Enumerable.Empty<UserModel>();
        }
    }
}