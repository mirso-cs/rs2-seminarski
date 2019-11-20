using System.ComponentModel.DataAnnotations;

namespace Source.net.infrastructure.Entities
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
    }
}
