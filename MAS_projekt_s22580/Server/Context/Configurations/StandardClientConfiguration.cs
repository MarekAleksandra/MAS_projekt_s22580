using MAS_projekt_s22580.Models.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MAS_projekt_s22580.Context.Configurations
{
    public class StandardClientConfiguration : IEntityTypeConfiguration<ClientStandard>
    {
        public void Configure(EntityTypeBuilder<ClientStandard> builder)
        {
            builder.HasData(
               new ClientStandard
               {
                   Id = 3,
                   Email = "jane.smith@example.com",
                   PersonId = 2,
                   LoyaltyPoints = 150
               },
                  new ClientStandard
                  {   Id = 4,
                      Email = "monica.williams@example.com",
                      PersonId = 4,
                      LoyaltyPoints = 125
                  }
           );

        }
    }
}
