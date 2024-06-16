using System.ComponentModel.DataAnnotations;

namespace MAS_projekt_s22580.Models.Guitars;

public class AcousticGuitar : GuitarType
{
    [Required]
    public string BodyType { get; set; } = null!;
}