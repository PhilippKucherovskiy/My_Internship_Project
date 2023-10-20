// UserController
using Microsoft.AspNetCore.Mvc;
using My_Internship_Project.Models;
using My_Internship_Project.Services;
using System;
using System.Threading.Tasks;

namespace My_Internship_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
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

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user, string role)
        {
            _userService.CreateUser(user, role);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

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
