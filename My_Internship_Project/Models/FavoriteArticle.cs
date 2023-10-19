using System.ComponentModel.DataAnnotations;

namespace My_Internship_Project.Models
{
    public class FavoriteArticle
    {
        [Key]
        public int UserId { get; set; }

        [Key]
        public int ArticleId { get; set; }

        public User User { get; set; }
        public Article Article { get; set; }
    }
}
