using Microsoft.EntityFrameworkCore;
using My_Internship_Project.Models;

namespace My_Internship_Project
{
    // ApplicationDbContext.cs
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }

}
