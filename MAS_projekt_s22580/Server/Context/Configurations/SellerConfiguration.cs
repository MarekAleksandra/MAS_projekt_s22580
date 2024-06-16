using MAS_projekt_s22580.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS_projekt_s22580.Context.Configurations
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasOne(e => e.Employee)
               .WithOne(p => p.Seller)
               .HasForeignKey<Seller>(c => c.EmployeeId)
               .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(e => e.Orders)
                   .WithOne(o => o.Seller)
                   .HasForeignKey(o => o.EmployeeID)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(
                       new Seller { Id=1, SalesTarget = 100, KnowledgeLevel = 3 , EmployeeId=1 },
                       new Seller { Id = 2, SalesTarget = 200, KnowledgeLevel = 9, EmployeeId=3}
                   );
        }
    }
}
