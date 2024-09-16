using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace NewsRepository.Helpers;

public class DatabaseContext : IdentityDbContext<IdentityUser>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) :
        base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //User setup
        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();
        
        //Article setup
        modelBuilder.Entity<Article>()
            .Property(a => a.ArticleId)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Article>()
            .HasOne(a => a.User)
            .WithMany(a => a.Articles)
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
        
        //Comment setup
        modelBuilder.Entity<Comment>()
            .Property(c => c.CommentId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(c => c.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Article)
            .WithMany(c => c.Comments)
            .HasForeignKey(c => c.ArticleId)
            .OnDelete(DeleteBehavior.Cascade);
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Comment> Comments { get; set; }

}