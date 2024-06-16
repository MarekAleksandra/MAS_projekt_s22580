using MAS_projekt_s22580.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MAS_projekt_s22580.Context.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasIndex(o => o.OrderNumber)
                .IsUnique();

            var converter = new EnumToStringConverter<Status>();
            builder.Property(o => o.Status)
                   .IsRequired()
                   .HasConversion(converter);

            builder.HasOne(o => o.Client)
                   .WithMany(c => c.Orders)
                   .HasForeignKey(o => o.ClientID)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Seller)
                   .WithMany(e => e.Orders)
                   .HasForeignKey(o => o.EmployeeID)
                   .OnDelete(DeleteBehavior.Cascade); ;

            builder.HasMany(o => o.Guitars)
                   .WithOne(g => g.Order)
                   .HasForeignKey(g => g.IdOrder)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
               new Order {Id = 1, OrderNumber = "A1234", Status = Status.Submitted, ClientID = 1, EmployeeID = 1 },
               new Order {Id = 2, OrderNumber = "B9876", Status = Status.Confirmed, ClientID = 2, EmployeeID = 2 },
               new Order {Id = 3, OrderNumber = "C1928", Status = Status.Completed, ClientID = 3, EmployeeID = 1 },
               new Order {Id = 4, OrderNumber = "D5678", Status = Status.Received, ClientID = 2, EmployeeID = 2 },
               new Order {Id = 5, OrderNumber = "E9876", Status = Status.Canceled, ClientID = 4, EmployeeID = 1 }
           );
        }
    }
}
