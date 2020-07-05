using Source.net.infrastructure.Entities;
using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Views;
using Source.net.infrastructure.Enums;
using Source.net.services.Services.Implementations;
using System.Resources;

namespace Source.net.services.Mappers
{
    public class UserMapper: Mapper<User, UserView, RegisterDto, UpdateUserDto>
    {
        private readonly RoleMapper _roleMapper;
        private readonly PasswordCryptoService _crytpoService;
        public UserMapper(RoleMapper roleMapper, PasswordCryptoService cryptoService)
        {
            _roleMapper = roleMapper;
            _crytpoService = cryptoService;
        }

        public User To(RegisterDto dto)
        {
            string salt = _crytpoService.GenerateSalt();
            string hash = _crytpoService.GenerateHash(salt, dto.Password);
            return new User
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                PasswordHash = hash,
                PasswordSalt = salt,
                Username = dto.Username,
                Role = Role.USER,
                Package = Package.NONE
            };
        }
        public User To(UpdateUserDto dto, User entity)
        {
            if(entity is null)
            {
                return null;
            }

            entity.Name = dto.Name;
            entity.Surname = dto.Surname;
            entity.Email = dto.Email;
            entity.Username = dto.Username;
            return entity;
        }
        public User To(UserView view)
        {
            return new User
            {
                Active = view.Active,
                Email = view.Email,
                Name = view.Name,
                Role = view.RoleId,
                Package = view.Package,
                Surname = view.Surname,
                Username = view.Username,
                PasswordHash = "HIDDEN"
            };
        }
        public UserView From(User entity)
        {
            return new UserView
            {
                Email = entity.Email,
                id = entity.id,
                Role = _roleMapper.ToString(entity.Role),
                Name = entity.Name,
                Surname = entity.Surname,
                Username = entity.Username,
                Package = entity.Package,
                RoleId = entity.Role,
                Active = entity.Active
            };
        }
    }
}