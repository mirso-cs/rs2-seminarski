using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class Tag
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
