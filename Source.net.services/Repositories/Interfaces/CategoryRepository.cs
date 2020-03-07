using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;

namespace Source.net.services.Repositories.Interfaces
{
    public interface CategoryRepository : Repository<Category, CategoryFilter>
    {
    }
}
