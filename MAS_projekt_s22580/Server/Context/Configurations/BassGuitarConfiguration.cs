using MAS_projekt_s22580.Models.Guitars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS_projekt_s22580.Context.Configurations
{
    public class BassGuitarConfiguration : IEntityTypeConfiguration<BassGuitar>
    {
        public void Configure(EntityTypeBuilder<BassGuitar> builder)
        {
            builder.HasData(
                new List<BassGuitar>()
                {
                    new BassGuitar
                    {
                        Id = 3,
                        NumberOfStrings = 4,
                        FretboardMaterial = "Maple",
                        BodyMaterial = "Alder",
                        Brand = "Fender",
                        Model = "Jazz Bass",
                        Price = 1200,
                        NumberOfFrets = 20,
                        BridgeType = "Fixed"
                    },
                    new BassGuitar
                    {
                        Id = 4,
                        NumberOfStrings = 5,
                        FretboardMaterial = "Rosewood",
                        BodyMaterial = "Mahogany",
                        Brand = "Ibanez",
                        Model = "SR505",
                        Price = 900,
                        NumberOfFrets = 24,
                        BridgeType = "Fixed"
                    }
                });
        }
    }
}