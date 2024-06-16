using MAS_projekt_s22580.Models.Guitars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MAS_projekt_s22580.Context.Configurations
{
    public class GuitarExemplarConfiguration : IEntityTypeConfiguration<GuitarExemplar>
    {
        public void Configure(EntityTypeBuilder<GuitarExemplar> builder)
        {
            builder.HasIndex(g => g.SerialNumber)
                .IsUnique();

            builder.HasOne(g => g.Order)
                   .WithMany(o => o.Guitars)
                   .HasForeignKey(g => g.IdOrder)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(g => g.Type)
                   .WithMany(t => t.GuitarExemplars)
                   .HasForeignKey(g => g.IdGuitarType)
                   .OnDelete(DeleteBehavior.Restrict);

             builder.HasData(
                new GuitarExemplar
                {
                    Id = 1,
                    SerialNumber = "SN1234",
                    IdGuitarType = 1,
                    IdOrder = 1
                },
                new GuitarExemplar
                {
                    Id = 2,
                    SerialNumber = "SN6789",
                    IdGuitarType = 2,
                    IdOrder = 2
                },
                new GuitarExemplar
                {      Id = 3,
                    SerialNumber = "SN9238",
                    IdGuitarType = 3,
                    IdOrder = 3
                }
        );}
    }

}
