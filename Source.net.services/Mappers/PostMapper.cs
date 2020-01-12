using Source.net.infrastructure.Entities;
using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Views;
using System.Collections.Generic;

namespace Source.net.services.Mappers
{
    public class PostMapper : Mapper<Post, PostView, CreatePostDto, UpdatePostDto>
    {
        private readonly TagMapper _tagMapper;
        public PostMapper(TagMapper tagMapper)
        {
            _tagMapper = tagMapper;
        }

        public PostView From(Post entity)
        {
            return new PostView
            {
                id = entity.id,
                CategoryId = entity.CategoryId,
                Content = entity.Content,
                Title = entity.Title,
                Published = entity.Published,
                Tags = mapTags(entity.AssociatedTags),
                Subtitle = entity.Subtitle,
                Thumbnail = entity.Thumbnail
            };
        }


        public Post To(CreatePostDto dto)
        {
            return new Post
            {
                Content = dto.Content,
                Title = dto.Title,
                Subtitle = dto.Subtitle,
                UserId = dto.UserId,
                Thumbnail = dto.Thumbnail,
                CategoryId = dto.CategoryId,
                Published = false,
            };
        }

        public Post To(PostView view)
        {
            return new Post
            {
                id = view.id,
                Content = view.Content,
                Title = view.Title,
                Subtitle = view.Subtitle,
                UserId = view.UserId,
                Thumbnail = view.Thumbnail,
                CategoryId = view.CategoryId,
                Published = view.Published
            };
        }

        public Post To(UpdatePostDto dto, Post entity)
        {
            entity.Published = dto.Published;
            entity.Subtitle = dto.Subtitle;
            entity.Title = dto.Title;
            entity.Content = dto.Content;
            entity.Thumbnail = dto.Thumbnail;
            entity.CategoryId = dto.CategoryId;
            
            return entity;
        }

        private List<TagView> mapTags(List<PostTag> postTags)
        {
            List<TagView> views = new List<TagView>();
            if (postTags != null)
            {
                foreach (var postTag in postTags)
                {
                    views.Add(_tagMapper.From(postTag.Tag));
                }
            }

            return views;
        }
    }
}