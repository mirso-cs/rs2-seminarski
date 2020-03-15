using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using Source.net.infrastructure.Views;
using Source.net.services.Database;
using Source.net.services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Source.net.services.Repositories.Implementations
{
    public class SqlServerUserPostCategoryRepository : MutatorRepository<UserPostCategory>, UserPostCategoryRepository
    {
        public SqlServerUserPostCategoryRepository(SourceNetContext db) :
            base(db)
        {
        }

        public IEnumerable<UserPostCategoryAggregate> GetAggregate(UserPostFilters filter)
        {
            return _db.UserPostCategories.Where(x => x.UserId == filter.UserId)
                .GroupBy(x => x.CategoryId)
                .Select(x => new UserPostCategoryAggregate()
                {
                    Count = x.Count(),
                    CategoryId = x.Key
                });
        }

        IEnumerable<UserPostCategory> Repository<UserPostCategory, UserPostFilters>.GetAll(UserPostFilters filter)
        {
            return _db.UserPostCategories.Where(x => x.UserId == filter.UserId).ToList();
        }
    }
}
