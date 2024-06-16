using System.ComponentModel.DataAnnotations;

namespace MAS_projekt_s22580.Models.Guitars;

public class ElectricGuitar : GuitarType
{
    [Required]
    public string PickupsType { get; set; } = null!;
}