using Infrastructure.Enums;
using System;

namespace Source.net.services.Mappers
{
    public class RoleMapper
    {
        private string[] Roles = new string[] { "Super user", "Admin", "User" };

        public string ToString(Role role)
        {
            switch (role)
            {
                case Role.SUPER_USER:
                    return "Super user";
                case Role.ADMIN:
                    return "Admin";
                case Role.USER:
                    return "User";
            }
            throw new Exception("Undefined role.");
        }


        public Role ToRole(string role)
        {
            switch (role)
            {
                case "Super user":
                    return Role.SUPER_USER;
                case "Admin":
                    return Role.ADMIN;
                case "User":
                    return Role.USER;
            }
            throw new Exception("Undefined role.");
        }


    }
}