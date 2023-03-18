using Microsoft.EntityFrameworkCore;
using Renting.DAL.Entities;

namespace Renting.DAL
{
    public class RentingDbContext : DbContext
    {
        public RentingDbContext(DbContextOptions<RentingDbContext> options) : base(options) { }
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<CountryOfOrigin> CountriesOfOrigin => Set<CountryOfOrigin>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Discount> Discounts => Set<Discount>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Penalty> Penalties => Set<Penalty>();
        public DbSet<PenaltyType> PenaltyTypes => Set<PenaltyType>();
        public DbSet<Rent> Rents => Set<Rent>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    }
}