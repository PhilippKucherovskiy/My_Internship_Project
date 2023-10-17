namespace My_Internship_Project.Models
{
    // Article.cs
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public List<ArticleTag> ArticleTags { get; set; }
        public int UserId { get; set; } // Внешний ключ автор-много статей
        public User Author { get; set; } // Навигационное свойство автор-много статей
        public ICollection<Comment> Comments { get; set; }//коллекция комментариев
        public ICollection<FavoriteArticle> FavoriteArticles { get; set; }


    }

}
