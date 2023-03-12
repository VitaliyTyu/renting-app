using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Renting.DAL.Entities;

namespace Renting.DAL.Configurations
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(x => x.Customer)
                .WithOne(customer => customer.Rent)
                .HasForeignKey<Customer>(customer => customer.RentId);
        }
    }
}
