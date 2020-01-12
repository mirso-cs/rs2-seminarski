using Source.net.infrastructure.Entities;
using System.Collections.Generic;

namespace Source.net.services.Repositories.Interfaces
{
    public interface PostTagRepository : Repository<PostTag>
    {
        ICollection<PostTag> GetByPost(int postId);
        void RemoveForPost(int postId);
    }

}
