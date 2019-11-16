using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Source.net.api.Database
{
    public class SourceNetContext : DbContext
    {
        public SourceNetContext(DbContextOptions<SourceNetContext> options)
           : base(options)
        {
        }

        public virtual DbSet<User> Users{ get; set; }
    }
}
