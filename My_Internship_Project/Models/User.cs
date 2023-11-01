using Microsoft.AspNetCore.Identity;

namespace My_Internship_Project.Models
{
    
    public class User : IdentityUser<int>
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
