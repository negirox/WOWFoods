using Microsoft.EntityFrameworkCore;
using WowFoods.Models;

namespace WowFoodsApp.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserInformation> UserInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserInformation)
                .WithOne(ui => ui.User)
                .HasForeignKey<UserInformation>(ui => ui.UserId);

            // Configure auto-incrementing primary keys
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserInformation>()
                .Property(ui => ui.Id)
                .ValueGeneratedOnAdd();
            // Seed initial data
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "123", UserType = "Admin" },
                new User { Id = 2, Username = "user", Password = "123", UserType = "User" }
            );

            modelBuilder.Entity<UserInformation>().HasData(
                new UserInformation { Id = 1, FirstName = "Admin", LastName = "User", Email = "admin@example.com", PhoneNumber = "1234567890", UserId = 1 },
                new UserInformation { Id = 2, FirstName = "Regular", LastName = "User", Email = "user@example.com", PhoneNumber = "0987654321", UserId = 2 }
            );
            base.OnModelCreating(modelBuilder);
        }
    }

}
