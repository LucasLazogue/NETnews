using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NETnews.Models;

namespace NETnews.Data {
    public class AppDbContext : IdentityDbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Comment>().HasKey(c => new {
                c.id,
                c.userId
            });

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.user)
                .WithMany(u => u.comments)
                .HasForeignKey(u => u.userId)
                .OnDelete(DeleteBehavior.Restrict);
            
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Journalist> Journalists { get; set; }
        public DbSet<News> News { get; set; } 
        public DbSet<Comment> NewsComments { get; set; }

    }
}
