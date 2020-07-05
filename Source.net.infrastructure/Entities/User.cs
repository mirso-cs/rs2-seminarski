using Source.net.infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace Source.net.infrastructure.Entities
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Token { get; set; }
        public Role Role { get; set; }
        public Package Package { get; set; } = Package.NONE;
        public bool Active { get; set; } = true;
    }
}
