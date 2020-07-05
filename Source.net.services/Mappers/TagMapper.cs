using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Entities;
using Source.net.infrastructure.Views;

namespace Source.net.services.Mappers
{
    public class TagMapper: Mapper<Tag, TagView, TagDto, TagDto>
    {
        public Tag To(TagView view)
        {
            return new Tag
            {
                name = view.Name
            };
        }

        public TagView From(Tag entity)
        {
            if(entity is null)
            {
                return new TagView();
            }

            return new TagView
            {
                Id = entity.id,
                Name = entity.name
            };
        }

        public Tag To(TagDto dto)
        {
            return new Tag() { name = dto.Name };
        }

        public Tag To(TagDto dto, Tag entity)
        {
            entity.name = dto.Name;
            return entity;
        }
    }
}