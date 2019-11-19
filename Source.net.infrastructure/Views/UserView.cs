using Source.net.infrastructure.Enums;

namespace Source.net.infrastructure.Views
{
    public class UserView
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public bool Active{ get; set; }
        public Role RoleId { get; set; }

        public bool isAdmin()
        {
            return RoleId <= Enums.Role.ADMIN;
        }
    }
}
