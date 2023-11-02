using My_Internship_Project.Models;

namespace My_Internship_Project.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUser(int id);
        Task CreateUser(User user, string role);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void CreateUserSubscription(UserSubscription subscription);
        void DeleteUserSubscription(int subscriberId, int targetUserId);
        void CreateUserAccount(UserAccount account);
        UserAccount GetUserAccount(int userId);
        Task AssignUserRole(int userId, string role);
    }

}
