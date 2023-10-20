using Microsoft.EntityFrameworkCore;
using My_Internship_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace My_Internship_Project
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<FavoriteArticle> FavoriteArticles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Subscriptions)
                .WithOne(s => s.Subscriber)
                .HasForeignKey(s => s.SubscriberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSubscription>()
                .HasOne(s => s.Subscriber)
                .WithMany(u => u.Subscriptions)
                .HasForeignKey(s => s.SubscriberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FavoriteArticle>()
                .HasKey(fa => new { fa.UserId, fa.ArticleId });

            modelBuilder.Entity<ArticleTag>()
                .HasKey(at => new { at.ArticleId, at.TagId });

            modelBuilder.Entity<UserSubscription>()
                .HasKey(us => new { us.SubscriberId, us.TargetUserId });
        }
    }
}
