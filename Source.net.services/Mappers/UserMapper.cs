using Infrastructure.Entities;
using Infrastructure.Dtos;
using Infrastructure.Views;
using Infrastructure.Enums;

namespace Source.net.services.Mappers
{
    public class UserMapper
    {
        private readonly RoleMapper _roleMapper;
        public UserMapper(RoleMapper roleMapper)
        {
            _roleMapper = roleMapper;
        }

        public User To(RegisterDto dto)
        {
            return new User
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                Password = dto.Password,
                Username = dto.Username,
                Role = Role.USER
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

        public UserView ToView(User entity)
        {
            return new UserView
            {
                Email = entity.Email,
                id = entity.id,
                Role = _roleMapper.ToString(entity.Role),
                Name = entity.Name,
                Surname = entity.Surname,
                Token = entity.Token,
                Username = entity.Username,
                RoleId = entity.Role,
                Active = entity.Active
            };
        }
    }
}