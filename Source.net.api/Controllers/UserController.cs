using Infrastructure.Dtos;
using Infrastructure.Exceptions;
using Infrastructure.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Source.net.api.Security;
using Source.net.services.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Source.net.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly AuthenticationService _authService;
        private readonly UserService _userService;

        public UserController(AuthenticationService authService, UserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserView> Get()
        {
            var authUser = getUser();
            if(!authUser.isAdmin())
            {
                throw new BadRequestException("User does not have permission for this action.");
            }
            return _userService.getAll();
        }

        [HttpGet]
        [Route("{userId}")]
        public UserView GetById(int userId)
        {
            var authUser = getUser();
            if (!authUser.isAdmin())
            {
                throw new BadRequestException("User does not have permission for this action.");
            }
            return _userService.getById(userId);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult RequestToken([FromBody] LoginDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }

            string token;
            if (_authService.IsAuthenticated(request, out token))
            {
                return Ok(new { token });
            }

            return BadRequest("Invalid Request");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }

            return Ok(_userService.register(request));
        }

        [HttpGet]
        [Route("me")]
        public UserView GetMe()
        {
            return getUser();
        }

        [HttpPatch]
        [Route("{userId}")]
        public UserView UpdateUser(int userId, [FromBody] UpdateUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            var authUser = getUser();
            if (authUser.isAdmin())
            {
                return _userService.updateUser(userId, dto);
            }

            var user = _userService.getById(userId);
            if (authUser.id == userId && user.Active)
            {
                return _userService.updateUser(userId, dto);
            }

            throw new BadRequestException("User does not have permission for this action.");
        }

        [HttpPut]
        [Route("{userId}/password")]
        public UserView UpdatePassword(int userId, [FromBody] UpdatePasswordDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            var authUser = getUser();
            if (authUser.isAdmin())
            {
                return _userService.updatePassword(userId, dto);
            }

            var user = _userService.getById(userId);
            if (authUser.id == userId && user.Active)
            {
                return _userService.updatePassword(userId, dto);
            }

            throw new BadRequestException("User does not have permission for this action.");
        }

        [Authorize(Roles = "Super user")]
        [HttpPut]
        [Route("{userId}/role")]
        public UserView UpdateRole(int userId, [FromBody] UpdateRoleDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            return _userService.updateRole(userId, dto);
        }

        [Authorize(Roles = "Super user")]
        [HttpPut]
        [Route("{userId}/restore")]
        public UserView RestoreUser(int userId)
        {
            return _userService.activateUser(userId);
        }

        [HttpDelete]
        [Route("{userId}")]
        public UserView UpdateRole(int userId)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            var authUser = getUser();
            if (authUser.isAdmin())
            {
                return _userService.deleteUser(userId);
            }

            var user = _userService.getById(userId);
            if (authUser.id == userId && user.Active)
            {
                return _userService.deleteUser(userId);
            }

            throw new BadRequestException("User does not have permission for this action.");
        }

        private UserView getUser()
        {
            var username = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First()?.Value;
            return _userService.getByUsername(username);
        }
    }
}