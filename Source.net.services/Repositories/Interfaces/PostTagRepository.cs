using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using System.Collections.Generic;

namespace Source.net.services.Repositories.Interfaces
{
    public interface PostTagRepository : Repository<PostTag, PostTagFilters>
    {
        ICollection<PostTag> GetByPost(int postId);
        void RemoveForPost(int postId);
    }

}
