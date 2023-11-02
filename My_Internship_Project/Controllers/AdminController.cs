using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Internship_Project.Models;
using My_Internship_Project.Services;


namespace My_Internship_Project.Services
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IPermissionService _permissionService;

        public AdminController(IUserService userService, IRoleService roleService, IPermissionService permissionService)
        {
            _userService = userService;
            _roleService = roleService;
            _permissionService = permissionService;
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser(User user, string role)
        {
            _userService.CreateUser(user, role);
            return CreatedAtAction(nameof(UserService.GetUser), new { id = user.Id }, user);
        }

        [HttpPut("update-user/{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("delete-user/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
