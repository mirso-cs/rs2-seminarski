using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Exceptions;
using Infrastructure.Views;
using Source.net.services.Mappers;
using Source.net.services.Repositories.Interfaces;
using Source.net.services.Services.Interfaces;
using System.Collections.Generic;

namespace Source.net.services.Services.Implementations
{
    public class UserServiceImp : UserService
    {
        private readonly UserMapper _userMapper;
        private readonly UserRepository _userRepository;

        public UserServiceImp(UserMapper userMapper, UserRepository userRepository)
        {
            _userMapper = userMapper;
            _userRepository = userRepository;
        }

        public UserView getByUsername(string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            return _userMapper.ToView(user);
        }

        public UserView register(RegisterDto dto)
        {
            if (_userRepository.GetByEmail(dto.Email) != null)
            {
                throw new BadRequestException("Email already in use.");
            }
            if (_userRepository.GetUserByUsername(dto.Username) != null)
            {
                throw new BadRequestException("Username already in use.");
            }
            var user = _userMapper.To(dto);
            _userRepository.AddUser(user);
            return _userMapper.ToView(user);
        }

        public UserView updateUser(int userId, UpdateUserDto dto)
        {
            var user = _userRepository.GetUser(userId);
            if (user.Email != dto.Email
                && _userRepository.GetByEmail(dto.Email) != null)
            {
                throw new BadRequestException("Email already in use.");
            }
            if (user.Username != dto.Username
                && _userRepository.GetUserByUsername(dto.Username) != null)
            {
                throw new BadRequestException("Username already in use.");
            }

            user = _userMapper.To(dto, user);
            _userRepository.UpdateUser(user);
            return _userMapper.ToView(user);
        }

        public UserView getById(int id)
        {
            var user = _userRepository.GetUser(id);
            return _userMapper.ToView(user);
        }

        public UserView updatePassword(int userId, UpdatePasswordDto dto)
        {
            if (dto.PassowrdConfirmation != dto.Password)
            {
                throw new BadRequestException("Passwords do not match.");
            }
            var user = _userRepository.GetUser(userId);
            user.Password = dto.Password;
            _userRepository.UpdateUser(user);
            return _userMapper.ToView(user);
        }

        public UserView updateRole(int userId, UpdateRoleDto dto)
        {
            var user = _userRepository.GetUser(userId);
            user.Role = dto.Role;
            _userRepository.UpdateUser(user);
            return _userMapper.ToView(user);
        }

        public UserView deleteUser(int userId)
        {
            var user = _userRepository.DeleteUser(userId);
            return _userMapper.ToView(user);
        }

        public UserView activateUser(int userId)
        {
            var user = _userRepository.ActivateUser(userId);
            return _userMapper.ToView(user);
        }

        public IEnumerable<UserView> getAll()
        {
            IEnumerable<User> entities = _userRepository.GetAll();
            List<UserView> users = new List<UserView>();
            foreach (User user in entities)
            {
                users.Add(_userMapper.ToView(user));
            }
            return users;

        }

    }
}
