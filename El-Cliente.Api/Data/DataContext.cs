using El_Cliente.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace El_Cliente.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Availability> Availability { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Branch>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Registration>().HasIndex(x => x.Identifier).IsUnique();
            modelBuilder.Entity<Transaction>().HasIndex(x => x.Identifier).IsUnique();
        }
    }
}