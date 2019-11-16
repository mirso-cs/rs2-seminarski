using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        public int Name { get; set; }
    }
}
