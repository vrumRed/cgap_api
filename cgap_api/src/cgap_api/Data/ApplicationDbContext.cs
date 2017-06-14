using cgap_api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgap_api.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ForeignKey_User_Department");

            builder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.ProfileID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ForeignKey_User_Profile");

            builder.Entity<Product>()
                .HasOne(p => p.Room)
                .WithMany(r => r.Products)
                .HasForeignKey(p => p.RoomID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ForeignKey_Product_Room");

            builder.Entity<Room>()
                .HasOne(r => r.Department)
                .WithMany(d => d.Rooms)
                .HasForeignKey(r => r.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ForeignKey_Room_Department");

            base.OnModelCreating(builder);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
