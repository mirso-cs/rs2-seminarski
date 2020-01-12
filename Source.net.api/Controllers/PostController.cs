using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Source.net.api.Exceptions;
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

        public PostController(PostService service, UserService userService) :
            base(service)
        {
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        public override PostView Add(CreatePostDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            var user = getUser();

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

            var user = getUser();
            var postUser = _userService.Get(post.UserId);

            if (!isAuthorized(user, postUser))
            {
                throw new BadRequestException("Not authorized for that action!");
            }

            if(postUser.id == user.id)
            {
                dto.Published = false; // if user updates post unpublish it
            }

            return _crudService.Update(id, dto);
        }

        private UserView getUser()
        {
            var username = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First()?.Value;
            return _userService.GetByUsername(username);
        }
        private bool isAuthorized(UserView authUser, UserView altUser)
        {
            if (authUser.isAdmin())
                return true;
            return authUser.id == altUser.id && altUser.Active;
        }

    }
}