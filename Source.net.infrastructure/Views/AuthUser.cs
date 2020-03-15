using Source.net.infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Source.net.infrastructure.Views
{
    public class AuthUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public Role RoleId { get; set; }
        public Package Package { get; set; }
        public string Role { get; set; }
    }
}
