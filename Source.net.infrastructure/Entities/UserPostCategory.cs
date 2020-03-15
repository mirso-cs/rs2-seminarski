using Source.net.infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace Source.net.infrastructure.Entities
{
    public class UserPostCategory
    {
        [Key]
        public int id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
