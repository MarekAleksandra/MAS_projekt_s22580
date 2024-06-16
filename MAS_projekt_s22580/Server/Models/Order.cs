using MAS_projekt_s22580.Models.Clients;
using MAS_projekt_s22580.Models.Employees;
using MAS_projekt_s22580.Models.Guitars;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_projekt_s22580.Models;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string OrderNumber { get; set; } = null!;
    [Required]
    public Status Status { get; set; } = Status.Submitted;
    public int ClientID { get; set; }
    public int? EmployeeID { get; set; } 
    public virtual BasicClient Client { get; set; } = null!;
    public virtual Seller Seller { get; set; } = null!;
    public virtual ICollection<GuitarExemplar> Guitars { get; set; } = null!;

}