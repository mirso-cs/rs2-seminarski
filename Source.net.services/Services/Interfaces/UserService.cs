using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.SearchFilters;
using Source.net.infrastructure.Views;
using System.Collections.Generic;

namespace Source.net.services.Services.Interfaces
{
    public interface UserService: 
        BaseService<UserService, RegisterDto, UpdateUserDto, UserView, UserFilters>
    {
        UserView GetByUsername(string username);
        UserView UpdatePassword(int userId, UpdatePasswordDto dto);
        UserView UpdateRole(int userId, UpdateRoleDto dto);
        UserView ActivateUser(int userId);
        UserView UpdatePackage(int userId);
        bool hasPermissions(int id);
    }
}
