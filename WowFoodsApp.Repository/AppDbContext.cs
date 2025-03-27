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

        public DbSet<EmployeeStaff> EmployeeStaffs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureRelationShipsofTable(modelBuilder);

            // Configure auto-incrementing primary keys
            ConfigureAutoIncrement(modelBuilder);

            // Seed initial data
            SeedInitialDataToDefaultTables(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SeedInitialDataToDefaultTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "123", UserType = "Admin" },
                new User { Id = 2, Username = "user", Password = "123", UserType = "User" }
            );

            modelBuilder.Entity<UserInformation>().HasData(
                new UserInformation { Id = 1, FirstName = "Admin", LastName = "User", Email = "admin@example.com", PhoneNumber = "1234567890", UserId = 1 },
                new UserInformation { Id = 2, FirstName = "Regular", LastName = "User", Email = "user@example.com", PhoneNumber = "0987654321", UserId = 2 }
            );

            modelBuilder.Entity<EmployeeStaff>().HasData(
                new EmployeeStaff { Id = 1, Salary = 6000, DateOfJoining = new DateTime(2020, 1, 1), IsActive = true, UserId = 1 },
                new EmployeeStaff { Id = 2, Salary = 8000, DateOfJoining = new DateTime(2021, 1, 1), IsActive = true, UserId = 2 }
            );
        }

        private static void ConfigureRelationShipsofTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserInformation)
                .WithOne(ui => ui.User)
                .HasForeignKey<UserInformation>(ui => ui.UserId);

            modelBuilder.Entity<EmployeeStaff>()
                .HasOne(e => e.User)
                .WithOne(u => u.EmployeeStaff)
                .HasForeignKey<EmployeeStaff>(e => e.Id);

            modelBuilder.Entity<User>()
                .HasOne(u => u.EmployeeStaff)
                .WithOne(e => e.User)
                .HasForeignKey<EmployeeStaff>(e => e.Id);

        }

        private static void ConfigureAutoIncrement(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserInformation>()
                .Property(ui => ui.Id)
                .ValueGeneratedOnAdd();

            //modelBuilder.Entity<EmployeeStaff>()
            //.HasKey(e => e.Id);

            modelBuilder.Entity<EmployeeStaff>()
             .Property(ui => ui.Id)
             .ValueGeneratedOnAdd();
        }
    }

}
