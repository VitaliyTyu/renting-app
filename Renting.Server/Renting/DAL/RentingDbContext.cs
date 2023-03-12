using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using Renting.DAL.Configurations;
using Renting.DAL.Entities;

namespace Lab9.App.DAL
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RentConfiguration());

            base.OnModelCreating(builder);
        }
    }
}