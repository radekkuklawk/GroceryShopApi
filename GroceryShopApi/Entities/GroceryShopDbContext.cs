using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Entities
{
    public class GroceryShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public GroceryShopDbContext(DbContextOptions<GroceryShopDbContext> options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
               .Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(20);

            modelBuilder.Entity<Client>()
               .Property(c => c.LastName)
               .IsRequired()
               .HasMaxLength(25);
               
            modelBuilder.Entity<Client>()
               .Property(c => c.City)
               .IsRequired()
               .HasMaxLength(25);

            modelBuilder.Entity<Client>()
                .Property(c => c.PostalCode)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Product>()
               .Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(20);

            modelBuilder.Entity<Product>()
              .Property(p => p.Price)
              .IsRequired();

            modelBuilder.Entity<Product>()
              .Property(p => p.Quantity)
              .IsRequired()
              .IsConcurrencyToken();

            modelBuilder.Entity<Order>()
             .Property(o => o.IdClient)
             .IsRequired();

            modelBuilder.Entity<Order>()
             .Property(o => o.DataOrder)
             .IsRequired();

            modelBuilder.Entity<OrderItem>()
             .Property(o => o.Quantity)
             .IsRequired()
             .IsConcurrencyToken();

            modelBuilder.Entity<OrderItem>()
             .Property(o => o.IdOrder)
             .IsRequired();

            modelBuilder.Entity<OrderItem>()
             .Property(o => o.IdProduct)
             .IsRequired();



            modelBuilder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                }
                );



        }
    }
}
