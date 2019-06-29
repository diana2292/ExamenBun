using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthenticationApi.Models;
using AuthenticationApi.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationApi.Authentication
{
    public class TokenAuthenticationService : IAuthenticateService
    {
        private readonly IUserService _userService;
        private readonly TokenManagement _tokenOptions;

        public TokenAuthenticationService(IUserService userService, IOptions<TokenManagement> tokenOptions)
        {
            _userService = userService;
            _tokenOptions = tokenOptions.Value;
        }

        public string Authenticate(UserLoginModel userLoginModel)
        {
            var user = _userService.GetUser(userLoginModel.Username, userLoginModel.Password);

            if (user == null)
                return null;

            var claim = new[]
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _tokenOptions.Issuer,
                _tokenOptions.Audience,
                claim,
                expires: DateTime.Now.AddMinutes(_tokenOptions.AccessExpiration),
                signingCredentials: credentials
            );

            return  new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
