using MAS_projekt_s22580.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS_projekt_s22580.Context.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.HasOne(c => c.Person)
                .WithOne(p => p.Employee)
                .HasForeignKey<Employee>(c => c.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Seller)
               .WithOne(e => e.Employee)
               .HasForeignKey<Seller>(e => e.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Specialist)
               .WithOne(e => e.Employee)
               .HasForeignKey<Specialist>(e => e.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);


            builder.HasData(
                 new Employee {Id= 1, Salary = 4500, EmploymentDate = DateTime.Now.AddDays(-10), PersonId = 1 },
                 new Employee {Id= 2, Salary = 5000, EmploymentDate = DateTime.Now.AddMonths(-16), PersonId = 2 },
                 new Employee {Id= 3, Salary = 5500, EmploymentDate = DateTime.Now.AddDays(-500), PersonId = 3 }
             );
        }
    }
}
