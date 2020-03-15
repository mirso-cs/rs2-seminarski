using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using System.Collections.Generic;

namespace Source.net.services.Repositories.Interfaces
{
    public interface PostRepository : Repository<Post, PostFilters>
    {
        IEnumerable<Post> GetForUser(int userId, PostFilters filters);
        IEnumerable<Post> GetPopular();
        IEnumerable<Post> GetLatest();
    }
}
