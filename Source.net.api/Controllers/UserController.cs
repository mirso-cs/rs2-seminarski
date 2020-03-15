using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Exceptions;
using Source.net.infrastructure.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Source.net.api.Security;
using Source.net.services.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Source.net.infrastructure.SearchFilters;
using Stripe;
using System;
using Source.net.api.Utils.HttpContext;

namespace Source.net.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AuthenticationService _authService;
        private readonly UserService _userService;
        private readonly HttpContextExtensible _httpContext;

        public UserController(AuthenticationService authService, UserService userService, HttpContextExtensible httpContext)
        {
            _authService = authService;
            _userService = userService;
            _httpContext = httpContext;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Super user")]
        public IEnumerable<UserView> Get([FromQuery]UserFilters filters)
        {
            return _userService.GetAll(filters);
        }

        [HttpGet]
        [Route("{userId}")]
        [Authorize(Roles = "Super user,Admin")]
        public UserView GetById(int userId)
        {
            return _userService.Get(userId);
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
                var user = _userService.GetByUsername(request.Username);

                return Ok(new AuthUser { 
                    Token = token, 
                    Username = request.Username,
                    RoleId = user.RoleId,
                    Role = user.Role,
                    Id = user.id
                });
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

            return Ok(_userService.Add(request));
        }

        [HttpGet]
        [Route("me")]
        [Authorize]
        public UserView GetMe()
        {
            var username = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First()?.Value;
            return _userService.GetByUsername(username);
        }

        [HttpPatch]
        [Route("{userId}")]
        [Authorize(Roles = "Super user,Admin")]
        public UserView UpdateUser(int userId, [FromBody] UpdateUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            return _userService.Update(userId, dto);
        }

        [HttpPut]
        [Route("{userId}/password")]
        [Authorize]
        public UserView UpdatePassword(int userId, [FromBody] UpdatePasswordDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            if (_userService.hasPermissions(userId))
            {
                return _userService.UpdatePassword(userId, dto);
            }

            throw new BadRequestException("User does not have permission for this action.");
        }

        [Authorize(Roles = "Admin,Super user")]
        [HttpPut]
        [Route("{userId}/role")]
        public UserView UpdateRole(int userId, [FromBody] UpdateRoleDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            return _userService.UpdateRole(userId, dto);
        }

        [Authorize(Roles = "Admin,Super user")]
        [HttpPut]
        [Route("{userId}/restore")]
        public UserView RestoreUser(int userId)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            return _userService.ActivateUser(userId);
        }

        [HttpDelete]
        [Route("{userId}")]
        [Authorize(Roles = "Admin,Super user")]
        public UserView UpdateRole(int userId)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            return _userService.Delete(userId);
        }

        [HttpPost]
        [Route("package")]
        public UserView UpdatePackage([FromBody]PaymentDto payment)
        {
            var user = _httpContext.getUserFromClaims(User.Claims);
            
            if(user is null)
            {
                throw new Exception("User not found.");
            }

            var charge = new ChargeCreateOptions()
            {
                Amount = 1000, 
                Currency = "EUR",
                Description = "Update user package",
                Source = payment.Token
            };

            var service = new ChargeService();

            try
            {
                var response = service.Create(charge);

                if(response.Status == "succeeded")
                {
                    var updatedUser = _userService.UpdatePackage(user.id);
                    return updatedUser;
                }

                throw new Exception("Unable to pay.");
            }
            catch (StripeException ex)
            {
                throw ex;
            }
        }

    }
}