using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Source.net.api.Exceptions;
using Source.net.api.Utils.HttpContext;
using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using Source.net.infrastructure.Views;
using Source.net.services.Repositories.Interfaces;
using Source.net.services.Services.Interfaces;
using System.Collections.Generic;

namespace Source.net.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : 
        CRUDController<
            Post,
            CreatePostDto, 
            UpdatePostDto, 
            PostView,
            PostFilters
        >
    {
        private readonly UserService _userService;
        private readonly HttpContextExtensible _httpContext;
        private readonly UserPostCategoryRepository _userPostCategories;
        private readonly UserPostTagRepository _userPostTags;

        public PostController(
            PostService service, 
            UserService userService, 
            HttpContextExtensible httpContext,
            UserPostCategoryRepository userPostCategories,
            UserPostTagRepository userPostTags
            ) :
            base(service)
        {
            _userService = userService;
            _httpContext = httpContext;
            _userPostCategories = userPostCategories;
            _userPostTags = userPostTags;
        }

        [HttpGet]
        public override IEnumerable<PostView> Get([FromQuery]PostFilters filter)
        {
            var user = _httpContext.getUserFromClaims(User.Claims);
            if(user.isAdmin())
            {
                return filter is null 
                    ? _crudService.GetAll() 
                    : _crudService.GetAll(filter);
            }

            return ((PostService)_crudService).GetAllForUser(user.id, filter);
        }

        [HttpGet("latest")]
        public IEnumerable<PostView> GetAll()
        {
            return ((PostService)_crudService).GetLatest();
        }

        [HttpGet("popular")]
        public IEnumerable<PostView> GetPopular()
        {
            return ((PostService)_crudService).GetPopular();
        }

        [HttpGet("suggested")]
        public IEnumerable<PostView> GetSuggested([FromQuery]UserPostFilters filters)
        {
            return ((PostService)_crudService).GetSuggested(filters);
        }


        [HttpGet]
        [Route("{id}")]
        public override PostView GetById(int id)
        {
            var user = _httpContext.getUserFromClaims(User.Claims);
            var post = _crudService.Get(id);

            var userCategory = new UserPostCategory()
            {
                CategoryId = post.CategoryId,
                UserId = user.id,
            };

            var userTags = new List<UserPostTag>();
            foreach(var item in post.Tags)
            {
                userTags.Add(new UserPostTag() { TagId = item.Id, UserId = user.id});
            }
            _userPostCategories.Add(userCategory);
            _userPostTags.BulkInsert(userTags);

            return post;
        }

        [HttpPost]
        [Authorize]
        public override PostView Add(CreatePostDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            var user = _httpContext.getUserFromClaims(User.Claims);

            if (user is null)
            {
                throw new BadRequestException("Invalid user!");
            }

            return ((PostService)_crudService).Add(dto, user.id);
        }

        [HttpPatch("{id}")]
        [Authorize]
        public override PostView Update(int id, UpdatePostDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            var post = _crudService.Get(id);

            if (post is null)
            {
                throw new BadRequestException("Unknown post!");
            }

            var user = _httpContext.getUserFromClaims(User.Claims);

            if(user is null)
            {
                throw new BadRequestException("Invalid user!");
            }

            var postUser = _userService.Get(post.UserId);

            if (!user.isAdmin() && postUser.id != user.id)
            {
                throw new BadRequestException("Not authorized for that action!");
            }

            if(!postUser.isAdmin())
            {
                dto.Published = false; // if user updates post unpublish it
            }

            return _crudService.Update(id, dto);
        }
    }
}