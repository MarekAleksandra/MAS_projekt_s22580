using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_projekt_s22580.Models.Guitars;

public abstract class GuitarType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

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
    [Range(0,double.MaxValue)]
    public double Price { get; set; }
    public virtual ICollection<GuitarExemplar> GuitarExemplars { get; set; } = null!;
}