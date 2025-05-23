﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WowFoodsApp.Repository;

#nullable disable

namespace WowFoodsApp.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250327125436_AddEmployeeStaff")]
    partial class AddEmployeeStaff
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WowFoods.Models.EmployeeStaff", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfJoining")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("EmployeeId");

                    b.ToTable("EmployeeStaff");
                });

            modelBuilder.Entity("WowFoods.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "123",
                            UserType = "Admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "123",
                            UserType = "User",
                            Username = "user"
                        });
                });

            modelBuilder.Entity("WowFoods.Models.UserInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserInformations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@example.com",
                            FirstName = "Admin",
                            LastName = "User",
                            PhoneNumber = "1234567890",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "user@example.com",
                            FirstName = "Regular",
                            LastName = "User",
                            PhoneNumber = "0987654321",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("WowFoods.Models.EmployeeStaff", b =>
                {
                    b.HasOne("WowFoods.Models.User", "User")
                        .WithOne("EmployeeStaff")
                        .HasForeignKey("WowFoods.Models.EmployeeStaff", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WowFoods.Models.UserInformation", b =>
                {
                    b.HasOne("WowFoods.Models.User", "User")
                        .WithOne("UserInformation")
                        .HasForeignKey("WowFoods.Models.UserInformation", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WowFoods.Models.User", b =>
                {
                    b.Navigation("EmployeeStaff");

                    b.Navigation("UserInformation");
                });
#pragma warning restore 612, 618
        }
    }
}
