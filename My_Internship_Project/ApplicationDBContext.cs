using Microsoft.EntityFrameworkCore;
using My_Internship_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace My_Internship_Project
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole<int>> roleManager;

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<FavoriteArticle> FavoriteArticles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .HasConversion<int>();

            modelBuilder.Entity<User>()
                .HasOne(u => u.Account)
                .WithOne(a => a.User)
                .HasForeignKey<UserAccount>(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

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

            SeedDefaultUsersAndRoles(userManager, roleManager).Wait();

        }

        
        private async Task SeedDefaultUsersAndRoles(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            var adminUser = new User
            {
                UserName = "admin",
                Email = "admin@example.com",
            };
            var moderatorUser = new User
            {
                UserName = "moderator",
                Email = "moderator@example.com",
            };
            var regularUser = new User
            {
                UserName = "user",
                Email = "user@example.com",
            };

            await userManager.CreateAsync(adminUser, "Password1");
            await userManager.CreateAsync(moderatorUser, "Password2");
            await userManager.CreateAsync(regularUser, "Password3");

            
            await userManager.AddToRoleAsync(adminUser, "Admin");
            await userManager.AddToRoleAsync(moderatorUser, "Moderator");
            await userManager.AddToRoleAsync(regularUser, "User");
        }
    }
}
