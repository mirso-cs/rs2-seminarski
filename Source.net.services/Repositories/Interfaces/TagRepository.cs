using Source.net.infrastructure.Entities;

namespace Source.net.services.Repositories.Interfaces
{
    public interface TagRepository : Repository<Tag>
    {

        Tag GetByName(string name);
    }
}
