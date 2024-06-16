using System.ComponentModel.DataAnnotations;


namespace MAS_projekt_s22580.Shared.DTOs
{
    public class GuitarTypeElectricPOST
    {
        [Required]
        [Range(4, int.MaxValue)]
        public int NumberOfStrings { get; set; }

        [Required]
        [MaxLength(60)]
        public string FretboardMaterial { get; set; } = null!;

        [Required]
        [MaxLength(60)]
        public string BodyMaterial { get; set; } = null!;

        [Required]
        [MaxLength(60)]
        public string Brand { get; set; } = null!;

        [Required]
        [MaxLength(60)]
        public string Model { get; set; } = null!;

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Required]
        public string PickupsType { get; set; } = null!;
    }
}
