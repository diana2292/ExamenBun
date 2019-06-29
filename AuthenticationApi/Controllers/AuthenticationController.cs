using System.Collections.Generic;
using AuthenticationApi.Authentication;
using AuthenticationApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApi.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authService;

        public AuthenticationController(IAuthenticateService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromBody] UserLoginModel userLoginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }

            var token = _authService.Authenticate(userLoginModel);

            if (token == null)
                return BadRequest("Invalid credentials.");

            return Ok(token);
        }
    }
}