using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using Source.net.services.Database;
using Source.net.services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Source.net.services.Repositories.Implementations
{
    public class SqlServerCategoryRepository : MutatorRepository<Category>, CategoryRepository
    {
        public SqlServerCategoryRepository(SourceNetContext db): 
            base(db)
        {
        }

        public IEnumerable<Category> GetAll(CategoryFilter filter)
        {
            var query = _db.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(x => x.Name.Contains(filter.Name));
            }

            return query.ToList();
        }
    }
}
