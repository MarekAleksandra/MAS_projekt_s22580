using MAS_projekt_s22580.Models.Employees;
using MAS_projekt_s22580.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using MAS_projekt_s22580.Models.Clients;

namespace MAS_projekt_s22580.Context.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasOne(p => p.Client)
                .WithOne(c => c.Person)
                .HasForeignKey<BasicClient>(c => c.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(p => p.Employee)
                .WithOne(c => c.Person)
                .HasForeignKey<Employee>(c => c.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
             new Person { Id = 1, FirstName = "John", LastName = "Doe" },
             new Person { Id = 2, FirstName = "Jane", LastName = "Smith" },
             new Person { Id = 3, FirstName = "Michael", LastName = "Collins" },
             new Person { Id = 4, FirstName = "Monica", LastName = "Williams" }
         );
        }
    }
}
