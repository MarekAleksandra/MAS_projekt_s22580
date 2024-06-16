using MAS_projekt_s22580.Models.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MAS_projekt_s22580.Context.Configurations
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.HasData(
            new PhoneNumber { Id = 1, Number = "123-456-789", ClientId = 1 },
            new PhoneNumber { Id = 2, Number = "098-765-432", ClientId = 1 },
            new PhoneNumber { Id = 3 ,Number = "111-111-111", ClientId = 2 },
            new PhoneNumber { Id = 4 ,Number = "222-222-222", ClientId = 3 },
            new PhoneNumber { Id = 5 ,Number = "987-654-321", ClientId = 4 },
            new PhoneNumber { Id = 6 ,Number = "555-555-555", ClientId = 4 });
        }
    }
}
