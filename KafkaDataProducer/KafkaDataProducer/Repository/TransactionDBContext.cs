using System;
using KafkaDataProducer.Models;
using Microsoft.EntityFrameworkCore;

namespace KafkaDataProducer.Repository
{
    class TransactionDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Merchant> Merchants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sqlserver,1433;Database=TransactionDb;user id=sa;password=Y37uigwzrUA%;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().SeedData(
                new Customer { Id = 1, FirstName = "Joe", LastName = "Blogs", CreatedDate = DateTime.UtcNow.AddDays(-5) },
                new Customer { Id = 2, FirstName = "Dave", LastName = "Smith", CreatedDate = DateTime.UtcNow.AddDays(-3) },
                new Customer { Id = 3, FirstName = "Adolf", LastName = "Walker", CreatedDate = DateTime.UtcNow.AddDays(-2) },
                new Customer { Id = 4, FirstName = "Steve", LastName = "Evans", CreatedDate = DateTime.UtcNow.AddDays(-1) },
                new Customer { Id = 5, FirstName = "Lee", LastName = "Brown", CreatedDate = DateTime.UtcNow.AddHours(-10) },
                new Customer { Id = 6, FirstName = "Jack", LastName = "Taylor", CreatedDate = DateTime.UtcNow.AddHours(-10) },
                new Customer { Id = 7, FirstName = "Alex", LastName = "Jones", CreatedDate = DateTime.UtcNow.AddHours(-9) },
                new Customer { Id = 8, FirstName = "Zee", LastName = "Smith", CreatedDate = DateTime.UtcNow.AddHours(-5) },
                new Customer { Id = 9, FirstName = "Nat", LastName = "Jones", CreatedDate = DateTime.UtcNow },
                new Customer { Id = 10, FirstName = "Will", LastName = "Smith", CreatedDate = DateTime.UtcNow }
            );
           
            modelBuilder.Entity<Merchant>().SeedData(
                new Merchant { Id = 1, TradingName = "Chicken Shop", City = "London", Postcode = "W1 4UT", CreatedDate = DateTime.UtcNow },
                new Merchant { Id = 2, TradingName = "Phone Shop", City = "London", Postcode = "SE10 0QW", CreatedDate = DateTime.UtcNow },
                new Merchant { Id = 3, TradingName = "My Taxis", City = "London", Postcode = "W1 4UT", CreatedDate = DateTime.UtcNow },
                new Merchant { Id = 4, TradingName = "MouseTrap", City = "London", Postcode = "W1 4UT", CreatedDate = DateTime.UtcNow },
                new Merchant { Id = 5, TradingName = "MagsRUs", City = "London", Postcode = "W1 4UT", CreatedDate = DateTime.UtcNow },
                new Merchant { Id = 6, TradingName = "House of Jack", City = "London", Postcode = "W1 4UT", CreatedDate = DateTime.UtcNow },
                new Merchant { Id = 7, TradingName = "Russion Poisions", City = "London", Postcode = "W1 4UT", CreatedDate = DateTime.UtcNow },
                new Merchant { Id = 8, TradingName = "Coffee Shop", City = "London", Postcode = "W1 4UT", CreatedDate = DateTime.UtcNow },
                new Merchant { Id = 9, TradingName = "Other Taxi", City = "London", Postcode = "W1 4UT", CreatedDate = DateTime.UtcNow },
                new Merchant { Id = 10, TradingName = "Another Taxi", City = "London", Postcode = "W1 4UT", CreatedDate = DateTime.UtcNow }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
