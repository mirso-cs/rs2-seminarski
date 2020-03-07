using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using Source.net.services.Database;
using Source.net.services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Source.net.services.Repositories.Implementations
{
    public class SqlServerTagRepository : MutatorRepository<Tag>, TagRepository
    {
        public SqlServerTagRepository(SourceNetContext db) :
            base(db)
        {
        }

        public IEnumerable<Tag> GetAll(TagFilters filter)
        {
            var query = _db.Tags.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(x => x.name.Contains(filter.Name));
            }

            return query.ToList();
        }

        public Tag GetByName(string name)
        {
            return _db.Tags.Where(t => t.name == name).FirstOrDefault();
        }
    }
}
