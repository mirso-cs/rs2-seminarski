using Source.net.infrastructure.Entities;
using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Views;
using Source.net.infrastructure.Enums;

namespace Source.net.services.Mappers
{
    public class UserMapper: Mapper<User, UserView, RegisterDto, UpdateUserDto>
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
        public User To(UserView view)
        {
            return new User
            {
                Active = view.Active,
                Email = view.Email,
                Name = view.Name,
                Role = view.RoleId,
                Surname = view.Surname,
                Username = view.Username,
                Password = "HIDDEN"
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
                RoleId = entity.Role,
                Active = entity.Active
            };
        }
    }
}