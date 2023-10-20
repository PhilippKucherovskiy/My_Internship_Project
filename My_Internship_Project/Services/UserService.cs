// UserService
using Microsoft.EntityFrameworkCore;
using My_Internship_Project.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Internship_Project.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserService(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            // Устанавливаем имя пользователя
            user.UserName = user.Email;

            // Создание пользователя
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                // Пароль
                await _userManager.AddPasswordAsync(user, user.Password);

                // Добавляем пользователя в роль
                await _userManager.AddToRoleAsync(user, role);
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

        // методы для работы с UserSubscription и UserAccount
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
