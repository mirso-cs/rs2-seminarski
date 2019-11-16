using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Source.net.api.Repositories.Interfaces;
using Source.net.api.Requests;
using Source.net.api.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Source.net.api.Security
{
    public class JWTAuthenticationService: AuthenticationService
    {
        private readonly TokenManagement _tokenManagement;
        private readonly UserRepository _userRepo;

        public JWTAuthenticationService(IOptions<TokenManagement> tokenManagement, UserRepository userRepo)
        {
            _tokenManagement = tokenManagement.Value;
            _userRepo = userRepo;
        }

        public bool IsAuthenticated(LoginRequest request, out string token)
        {
            token = string.Empty;
            var user = _userRepo.GetUserByUsername(request.Username);
            if (user is null || user.Password != request.Password)
            {
                return false;
            }

            var claim = new[]
            {
                new Claim(ClaimTypes.Name, request.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _tokenManagement.Issuer,
                _tokenManagement.Audience,
                claim,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            _userRepo.SetToken(request.Username, token);
            return true;
        }
    }
}
