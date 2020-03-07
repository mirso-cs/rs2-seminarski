using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using Source.net.services.Database;
using Source.net.services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Source.net.services.Repositories.Implementations
{
    public class SqlServerPostTagRepository : MutatorRepository<PostTag>, PostTagRepository
    {
        public SqlServerPostTagRepository(SourceNetContext db) :
            base(db)
        {
        }

        public IEnumerable<PostTag> GetAll(PostTagFilters filter)
        {
            var query = _db.PostTags.AsQueryable();

            if(!string.IsNullOrWhiteSpace(filter.Tag))
            {
                query = query.Where(x => x.Tag.name.Contains(filter.Tag));
            }

            if(filter.PostId.HasValue)
            {
                query = query.Where(x => x.PostId == filter.PostId);
            }

            return query.ToList();
        }

        public ICollection<PostTag> GetByPost(int postId)
        {
            return _db.PostTags.Where(p => p.PostId == postId).ToList();
        }

        public void RemoveForPost(int postId)
        {
            _db.PostTags.RemoveRange(GetByPost(postId));
        }
    }
}
