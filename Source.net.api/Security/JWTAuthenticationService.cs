using Source.net.infrastructure.Dtos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Source.net.services.Repositories.Interfaces;
using Source.net.api.Utils;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Source.net.services.Mappers;

namespace Source.net.api.Security
{
    public class JWTAuthenticationService : AuthenticationService
    {
        private readonly TokenManagement _tokenManagement;
        private readonly UserRepository _userRepo;
        private readonly RoleMapper _roleMapper;

        public JWTAuthenticationService(IOptions<TokenManagement> tokenManagement, UserRepository userRepo, RoleMapper roleMapper)
        {
            _tokenManagement = tokenManagement.Value;
            _userRepo = userRepo;
            _roleMapper = roleMapper;
        }

        public bool IsAuthenticated(LoginDto request, out string token)
        {
            token = string.Empty;
            var user = _userRepo.GetUserByUsername(request.Username);
            if (user is null || !user.Active || user.Password != request.Password)
            {
                return false;
            }

            var claim = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Name, user.Name + ' ' + user.Surname),
                new Claim(ClaimTypes.Role, _roleMapper.ToString(user.Role))
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
