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
using Source.net.services.Services.Implementations;

namespace Source.net.api.Security
{
    public class JWTAuthenticationService : AuthenticationService
    {
        private readonly TokenManagement _tokenManagement;
        private readonly UserRepository _userRepo;
        private readonly RoleMapper _roleMapper;
        private readonly PasswordCryptoService _cryptoService;


        public JWTAuthenticationService(IOptions<TokenManagement> tokenManagement, UserRepository userRepo, RoleMapper roleMapper, PasswordCryptoService cryptoService)
        {
            _tokenManagement = tokenManagement.Value;
            _userRepo = userRepo;
            _roleMapper = roleMapper;
            _cryptoService = cryptoService;
        }

        public bool IsAuthenticated(LoginDto request, out string token)
        {
            token = string.Empty;
            var user = _userRepo.GetUserByUsername(request.Username);


            if (user is null || !user.Active)
            {
                return false;
            }
            var newHash = _cryptoService.GenerateHash(user.PasswordSalt, request.Password);

            if (newHash != user.PasswordHash)
            {
                return false;
            }


            var claims = new[]
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
                claims,
                expires: DateTime.Now.AddDays(_tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            _userRepo.SetToken(request.Username, token);
            return true;
        }
    }
}
