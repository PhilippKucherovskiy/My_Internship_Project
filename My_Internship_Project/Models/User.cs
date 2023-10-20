using Microsoft.AspNetCore.Identity;

namespace My_Internship_Project.Models
{
    // User.cs
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Article> Articles { get; set; }//Навигация пользователь-много статей
        public UserAccount Account { get; set; }
        public ICollection<UserSubscription> Subscriptions { get; set; }
    }

}
