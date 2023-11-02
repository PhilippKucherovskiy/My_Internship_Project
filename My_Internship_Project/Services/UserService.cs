using Microsoft.EntityFrameworkCore;
using My_Internship_Project.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace My_Internship_Project.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _roleManager = roleManager;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public async Task CreateUser(User user, string role)
        {
            user.UserName = user.Email;
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                await _userManager.AddPasswordAsync(user, user.Password);
                await _userManager.AddToRoleAsync(user, role);

                var roles = await _userManager.GetRolesAsync(user);
                var claims = new List<Claim>();
                foreach (var userRole in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var identity = new ClaimsIdentity(claims, "custom");
                var principal = new ClaimsPrincipal(identity);

                await _httpContextAccessor.HttpContext.SignInAsync("custom", principal);
            }
        }


        public async Task AssignUserRole(int userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new InvalidOperationException("Пользователь не найден.");
            }

            if (!await _roleManager.RoleExistsAsync(role))
            {
                throw new InvalidOperationException("Роль не существует.");
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            if (currentRoles.Contains(role))
            {
                throw new InvalidOperationException("У пользователя уже есть указанная роль.");
            }

            var result = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Не получилось назначить роль пользователю.");
            }
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = GetUser(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void CreateUserSubscription(UserSubscription subscription)
        {
            _context.UserSubscriptions.Add(subscription);
            _context.SaveChanges();
        }

        public void DeleteUserSubscription(int subscriberId, int targetUserId)
        {
            var subscription = _context.UserSubscriptions
                .FirstOrDefault(s => s.SubscriberId == subscriberId && s.TargetUserId == targetUserId);

            if (subscription != null)
            {
                _context.UserSubscriptions.Remove(subscription);
                _context.SaveChanges();
            }
        }

        public void CreateUserAccount(UserAccount account)
        {
            _context.UserAccounts.Add(account);
            _context.SaveChanges();
        }

        public UserAccount GetUserAccount(int userId)
        {
            return _context.UserAccounts.FirstOrDefault(account => account.UserId == userId);
        }
    }
}
