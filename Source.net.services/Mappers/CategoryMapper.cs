using Source.net.infrastructure.Entities;
using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Views;

namespace Source.net.services.Mappers
{
    public class CategoryMapper : Mapper<Category, CategoryView, CategoryDto, CategoryDto>
    {
        public CategoryView From(Category entity)
        {
            return new CategoryView
            {
                id = entity.id,
                Name = entity.Name
            };
        }

        public Category To(CategoryDto dto)
        {
            return new Category
            {
                Name = dto.Name
            };
        }

        public Category To(CategoryView view)
        {
            return new Category
            {
                Name = view.Name
            };
        }

        public Category To(CategoryDto dto, Category entity)
        {
            entity.Name = dto.Name;
            return entity;
        }
    }
}