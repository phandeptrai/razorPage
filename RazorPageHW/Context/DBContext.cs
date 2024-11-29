using Microsoft.EntityFrameworkCore;
using RazorPageHW.Models;

namespace RazorPageHW.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ImgProduct> ImgProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Contact> contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)"); // Chỉ định kiểu dữ liệu cho cột Price trong SQL Server
        }



    }
}

