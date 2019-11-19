using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Source.net.infrastructure.Entities
{
    public class Comment
    {
        [Key]
        public int id { get; set; }
        public int Name { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
        public int PostId { get; set; }

        public Comment Reply { get; set; }
        public int CommentId { get; set; }
    }
}
