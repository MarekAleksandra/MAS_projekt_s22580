using MAS_projekt_s22580.Models.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MAS_projekt_s22580.Context.Configurations
{
    public class VipClientConfiguration : IEntityTypeConfiguration<ClientVip>
    {
        public void Configure(EntityTypeBuilder<ClientVip> builder)
        {
            builder.HasData(
               new ClientVip
               {
                   Id = 1,
                   Email = "john.doe@email.com",
                   PersonId = 1, 
                   VipMembershipLevel = 3
               },
               new ClientVip
               {
                   Id = 2,
                   Email = "michael.collins@email.com",
                   PersonId = 3,
                   VipMembershipLevel = 10
               }
           );
        }
    }
}
