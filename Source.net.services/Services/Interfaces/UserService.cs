using Infrastructure.Dtos;
using Infrastructure.Views;
using System.Collections.Generic;

namespace Source.net.services.Services.Interfaces
{
    public interface UserService
    {
        UserView register(RegisterDto dto);
        UserView getByUsername(string username);
        UserView getById(int id);
        UserView updateUser(int userId, UpdateUserDto dto);
        UserView updatePassword(int userId, UpdatePasswordDto dto);
        UserView updateRole(int userId, UpdateRoleDto dto);
        UserView deleteUser(int userId);
        UserView activateUser(int userId);
        IEnumerable<UserView> getAll();
    }
}
