namespace My_Internship_Project.Models
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ProfileImageUri { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        

        public int UserId { get; set; }
        public User User { get; set; } // Навигационное свойство
    }
}
