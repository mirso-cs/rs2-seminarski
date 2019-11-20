using Source.net.infrastructure.Entities;
using Source.net.services.Database;
using Source.net.services.Repositories.Interfaces;
using System.Linq;

namespace Source.net.services.Repositories.Implementations
{
    public class SqlServerCategoryRepository : MutatorRepository<Category>, CategoryRepository
    {
        public SqlServerCategoryRepository(SourceNetContext db): 
            base(db)
        {
        }
    }
}
