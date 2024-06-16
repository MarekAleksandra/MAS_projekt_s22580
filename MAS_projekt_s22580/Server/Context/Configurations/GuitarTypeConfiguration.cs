using MAS_projekt_s22580.Models.Guitars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MAS_projekt_s22580.Context.Configurations
{
    public class GuitarTypeConfiguration : IEntityTypeConfiguration<GuitarType>
    {
        public void Configure(EntityTypeBuilder<GuitarType> builder)
        {
               builder.HasMany(g => g.GuitarExemplars)
               .WithOne(e => e.Type)
               .HasForeignKey(e => e.IdGuitarType)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
