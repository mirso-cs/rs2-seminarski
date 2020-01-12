using Source.net.infrastructure.Entities;
using Source.net.infrastructure.Views;

namespace Source.net.services.Mappers
{
    public class TagMapper
    {
        public Tag To(TagView view)
        {
            return new Tag
            {
                name = view.name
            };
        }

        public TagView From(Tag entity)
        {
            return new TagView
            {
                id = entity.id,
                name = entity.name
            };
        }
    }
}