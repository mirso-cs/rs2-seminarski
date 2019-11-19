using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Source.net.infrastructure.Entities
{
    public class PostTag
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
        public int PostId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
