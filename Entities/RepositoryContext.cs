using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiies
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public RepositoryContext(DbContextOptions options)
            : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany<Category>(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity(x => x.ToTable("ProductCategory"));

            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Product>()
                .Property(p => p.Quantity)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Cost)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Picture)
                .HasDefaultValue("Into");

            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>()
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<ProductUser>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductUser>()
                .Property(p => p.Quantity)
                .IsRequired();
        }
    }
}
