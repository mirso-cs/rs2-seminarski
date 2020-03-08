using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using Source.net.infrastructure.Views;
using Source.net.services.Mappers;
using Source.net.services.Repositories.Interfaces;
using Source.net.services.Services.Interfaces;
using System.Collections.Generic;

namespace Source.net.services.Services.Implementations
{
    public class PostServiceImp : 
        BaseServiceImp<
            Post, 
            PostView, 
            PostMapper, 
            PostRepository, 
            CreatePostDto, 
            UpdatePostDto, 
            PostFilters
        >,
        PostService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly TagRepository _tagRepository;
        private readonly PostTagRepository _postTagRepository;

        public PostServiceImp(
            PostMapper mapper, 
            PostRepository repository,
            CategoryRepository categoryRepository,
            TagRepository tagRepository,
            PostTagRepository postTagRepository
        ): 
            base(mapper, repository)
        {
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _postTagRepository = postTagRepository;
        }

        public PostView Add(CreatePostDto dto, int userId)
        {
            var entity = _mapper.To(dto);

            var category = _categoryRepository.Get(dto.CategoryId);
            if(category is null)
            {
                throw new System.Exception("Category not found!");
            }

            entity.UserId = userId;
            Post post = _repo.Add(entity);

            addTags(dto.Tags, post.id);

            return _mapper.From(entity);
        }

        public override PostView Update(int id, UpdatePostDto dto)
        {
            var entity = _repo.Get(id);
            _postTagRepository.RemoveForPost(entity.id);
            addTags(dto.Tags, entity.id);
            var post = _repo.Update(_mapper.To(dto, entity));

            return _mapper.From(_repo.Get(id));
        }

        private void addTags(string[] Tags, int postId)
        {
            List<PostTag> postTags = new List<PostTag>();

            foreach (var tag in Tags)
            {
                var assignTag = _tagRepository.GetByName(tag);
                if (assignTag is null)
                {
                    assignTag = new Tag { name = tag };
                    _tagRepository.Add(assignTag);
                }

                postTags.Add(new PostTag { TagId = assignTag.id, PostId = postId });
            }

            _postTagRepository.BulkInsert(postTags);
        }
    }
}
