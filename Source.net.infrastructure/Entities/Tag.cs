using System.ComponentModel.DataAnnotations;

namespace Source.net.infrastructure.Entities
{
    public class Tag
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
