using Infrastructure.Dtos;
using Infrastructure.Views;
using System.Collections.Generic;

namespace Source.net.services.Services.Interfaces
{
    public interface UserService: 
        BaseService<UserService, RegisterDto, UpdateUserDto, UserView>
    {
        UserView GetByUsername(string username);
        UserView UpdatePassword(int userId, UpdatePasswordDto dto);
        UserView UpdateRole(int userId, UpdateRoleDto dto);
        UserView ActivateUser(int userId);
    }
}
