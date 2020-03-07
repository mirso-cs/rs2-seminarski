using Microsoft.EntityFrameworkCore;
using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using Source.net.services.Database;
using Source.net.services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Source.net.services.Repositories.Implementations
{
    public class SqlServerPostRepository : MutatorRepository<Post>, PostRepository
    {
        public SqlServerPostRepository(SourceNetContext db) :
            base(db)
        {
        }

        public override Post Get(int id)
        {
            return _db.Posts
                .Include(p => p.AssociatedTags)
                .ThenInclude(pt => pt.Tag)
                .Where(p => p.id == id)
                .FirstOrDefault();
        }

        public override IEnumerable<Post> GetAll()
        {
            return _db.Posts
                .Include(p => p.AssociatedTags)
                .ThenInclude(pt => pt.Tag)
                .ToList();
        }

        public IEnumerable<Post> GetAll(PostFilters filter)
        {
            var query = _db.Posts.AsQueryable();

            return query.ToList();
        }
    }
}
