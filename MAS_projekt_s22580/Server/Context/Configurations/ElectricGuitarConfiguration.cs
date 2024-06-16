using MAS_projekt_s22580.Models.Guitars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS_projekt_s22580.Context.Configurations
{
    public class ElectricGuitarConfiguration : IEntityTypeConfiguration<ElectricGuitar>
    {
        public void Configure(EntityTypeBuilder<ElectricGuitar> builder)
        {

            builder.HasData(
                new List<ElectricGuitar>()
                {
                    new ElectricGuitar
                    {
                        Id=5,
                        NumberOfStrings = 6,
                        FretboardMaterial = "Maple",
                        BodyMaterial = "Alder",
                        Brand = "Fender",
                        Model = "Stratocaster",
                        Price = 1500,
                        PickupsType = "Single Coil"
                    },
                    new ElectricGuitar
                    {
                        Id=6,
                        NumberOfStrings = 6,
                        FretboardMaterial = "Rosewood",
                        BodyMaterial = "Mahogany",
                        Brand = "Gibson",
                        Model = "Les Paul",
                        Price = 2500,
                        PickupsType = "Humbucker"
                    }
                });
        }
    }
}
