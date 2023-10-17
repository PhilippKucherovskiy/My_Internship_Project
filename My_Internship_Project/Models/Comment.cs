namespace My_Internship_Project.Models
{
    // Comment.cs
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public int CommentId { get; set; }
        
        public int ArticleId { get; set; } 
        public Article Article { get; set; } 
    }

}
