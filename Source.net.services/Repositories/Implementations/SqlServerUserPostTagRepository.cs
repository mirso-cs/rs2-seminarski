using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using Source.net.infrastructure.Views;
using Source.net.services.Database;
using Source.net.services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Source.net.services.Repositories.Implementations
{
    public class SqlServerUserPostTagRepository : MutatorRepository<UserPostTag>, UserPostTagRepository
    {
        public SqlServerUserPostTagRepository(SourceNetContext db) :
            base(db)
        {
        }

        public IEnumerable<UserPostTag> GetAll(UserPostFilters filter)
        {
            return _db.UserPostTags.Where(x => x.UserId == filter.UserId).ToList();
        }

        public IEnumerable<UserPostTagAggregate> GetAggregate(UserPostFilters filter)
        {
            return _db.UserPostTags.Where(x => x.UserId == filter.UserId)
                .GroupBy(x => x.TagId)
                .Select(x => new UserPostTagAggregate()
                {
                    Count = x.Count(),
                    TagId = x.Key
                });
        }

    }
}
