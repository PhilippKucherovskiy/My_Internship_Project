namespace My_Internship_Project.Models
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; } // Внешний ключ
        public User User { get; set; } // Навигационное свойство
    }
}
