using System.ComponentModel.DataAnnotations;

namespace MAS_projekt_s22580.Models.Guitars;

public class BassGuitar :GuitarType
{
    [Required]
    [Range(12, int.MaxValue)]
    public int NumberOfFrets { get; set; }
    [Required]
    public string BridgeType { get; set; } = null!;
}