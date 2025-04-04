using MessageusApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageusApp.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define your DB sets here
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define your model here
            
            modelBuilder.Entity<User>().HasOne(u => u.Subscription).WithOne(u => u.User).HasForeignKey<Subscription>(s => s.UserId);
            modelBuilder.Entity<Message>().HasOne(m => m.User).WithMany(u => u.Messages).HasForeignKey(m => m.UserId);
        }
    }
}
