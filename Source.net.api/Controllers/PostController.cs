using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Source.net.api.Exceptions;
using Source.net.api.Utils.HttpContext;
using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Entities;
using Source.net.infrastructure.Views;
using Source.net.services.Services.Interfaces;

namespace Source.net.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : CRUDController<Post, CreatePostDto, UpdatePostDto, PostView>
    {
        private readonly UserService _userService;
        private readonly HttpContextExtensible _httpContext;

        public PostController(PostService service, UserService userService, HttpContextExtensible httpContext) :
            base(service)
        {
            _userService = userService;
            _httpContext = httpContext;
        }

        [HttpPost]
        [Authorize]
        public override PostView Add(CreatePostDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            var user = _httpContext.getUser();

            return ((PostService)_crudService).Add(dto, user.id);
        }

        [HttpPatch]
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

            var user = _httpContext.getUser();
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