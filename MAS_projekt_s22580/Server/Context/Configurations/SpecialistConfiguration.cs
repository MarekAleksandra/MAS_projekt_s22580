using MAS_projekt_s22580.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS_projekt_s22580.Context.Configurations
{
    public class SpecialistConfiguration : IEntityTypeConfiguration<Specialist>
    {
        public void Configure(EntityTypeBuilder<Specialist> builder)
        {
            builder.HasOne(e => e.Employee)
              .WithOne(p => p.Specialist)
              .HasForeignKey<Specialist>(c => c.EmployeeId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
              new Specialist {Id = 3, Specialization = "Electric guitars", YearsOfExperience = 6, EmployeeId =1 },
              new Specialist {Id = 4, Specialization = "Acoustic guitars", YearsOfExperience = 6, EmployeeId = 2 }
                 );
        }
    }
}
