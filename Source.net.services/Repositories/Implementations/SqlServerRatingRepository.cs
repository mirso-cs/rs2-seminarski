using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using Source.net.services.Database;
using Source.net.services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Source.net.services.Repositories.Implementations
{
    public class SqlServerRatingRepository : MutatorRepository<Rating>, RatingRepository
    {
        public SqlServerRatingRepository(SourceNetContext db) :
            base(db)
        {
        }

        public IEnumerable<Rating> GetAll(RatingFilters filter)
        {
            var query = _db.Ratings.AsQueryable();

            if (filter.PostId.HasValue)
            {
                query = query.Where(x => x.PostId == filter.PostId);
            }

            return query.ToList();
        }
    }
}
