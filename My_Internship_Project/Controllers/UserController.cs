using Microsoft.AspNetCore.Identity;
using My_Internship_Project.Models;
using My_Internship_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace My_Internship_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("assign-role")]
        public IActionResult AssignUserRole(int userId, string role)
        {
            
            if (!User.IsInRole("Admin"))
            {
                return Forbid(); 
            }

            
            _userService.AssignUserRole(userId, role);

            return Ok($"Role '{role}' assigned to user with ID {userId}");
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user, string role)
        {
            _userService.CreateUser(user, role);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            _userService.UpdateUser(user);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            _userService.DeleteUser(id);
            return NoContent();
        }

        [HttpPost("subscriptions")]
        public IActionResult CreateUserSubscription(UserSubscription subscription)
        {
            _userService.CreateUserSubscription(subscription);
            return CreatedAtAction(nameof(GetUser), new { id = subscription.SubscriberId }, subscription);
        }

        [HttpDelete("subscriptions/{subscriberId}/{targetUserId}")]
        public IActionResult DeleteUserSubscription(int subscriberId, int targetUserId)
        {
            _userService.DeleteUserSubscription(subscriberId, targetUserId);
            return NoContent();
        }

        [HttpPost("account")]
        public IActionResult CreateUserAccount(UserAccount account)
        {
            _userService.CreateUserAccount(account);
            return CreatedAtAction(nameof(GetUserAccount), new { userId = account.UserId }, account);
        }

        [HttpGet("account/{userId}")]
        public IActionResult GetUserAccount(int userId)
        {
            var account = _userService.GetUserAccount(userId);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }
    }

}
