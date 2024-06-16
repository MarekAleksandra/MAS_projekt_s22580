using MAS_projekt_s22580.Models.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS_projekt_s22580.Context.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<BasicClient>
    {
        public void Configure(EntityTypeBuilder<BasicClient> builder)
        {
            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Client)
                .HasForeignKey(o => o.ClientID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Person)
                .WithOne(p => p.Client)
                .HasForeignKey<BasicClient>(c => c.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.PhoneNumbers)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
