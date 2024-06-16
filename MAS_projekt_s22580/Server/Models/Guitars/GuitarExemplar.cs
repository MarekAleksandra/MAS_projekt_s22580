using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_projekt_s22580.Models.Guitars;

public class GuitarExemplar
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string SerialNumber { get; set; } = null!;
    [Required]
    public int IdGuitarType { get; set; }
    public int IdOrder { get; set; }
    public virtual Order Order { get; set; } = null!;
    public virtual GuitarType Type { get; set; } = null!;
}