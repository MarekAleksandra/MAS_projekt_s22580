
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_projekt_s22580.Models.Clients;

public abstract class BasicClient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(80)]
    public string Email { get; set; } = null!;
    [Required]
    public int PersonId { get; set; }
    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
    public virtual ICollection<Order> Orders { get; set; } = null!;
}