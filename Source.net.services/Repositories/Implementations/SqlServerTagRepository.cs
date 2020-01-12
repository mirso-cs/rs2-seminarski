using Source.net.infrastructure.Entities;
using Source.net.services.Database;
using Source.net.services.Repositories.Interfaces;
using System.Linq;

namespace Source.net.services.Repositories.Implementations
{
    public class SqlServerTagRepository : MutatorRepository<Tag>, TagRepository
    {
        public SqlServerTagRepository(SourceNetContext db) :
            base(db)
        {
        }

        public Tag GetByName(string name)
        {
            return _db.Tags.Where(t => t.name == name).FirstOrDefault();
        }
    }
}
