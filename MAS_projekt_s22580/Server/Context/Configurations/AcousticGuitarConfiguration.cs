using MAS_projekt_s22580.Models.Guitars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS_projekt_s22580.Context.Configurations;

public class AcousticGuitarConfiguration : IEntityTypeConfiguration<AcousticGuitar>
{
    public void Configure(EntityTypeBuilder<AcousticGuitar> builder)
    {
        builder.HasData(
             new List<AcousticGuitar>()
             {
                    new AcousticGuitar
                    {
                        Id = 1,
                        NumberOfStrings = 6,
                        FretboardMaterial = "Rosewood",
                        BodyMaterial = "Spruce",
                        Brand = "Yamaha",
                        Model = "F310",
                        Price = 150,
                        BodyType = "Dreadnought"
                    },
                    new AcousticGuitar
                    {
                        Id = 2,
                        NumberOfStrings = 6,
                        FretboardMaterial = "Ebony",
                        BodyMaterial = "Cedar",
                        Brand = "Taylor",
                        Model = "214ce",
                        Price = 1000,
                        BodyType = "Grand Auditorium"
                    }
             });
    }
}