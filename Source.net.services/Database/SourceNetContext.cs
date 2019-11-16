using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Source.net.services.Database
{
    public class SourceNetContext : DbContext
    {
        public SourceNetContext(DbContextOptions<SourceNetContext> options)
           : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<PostTag> PostTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
    }
}
