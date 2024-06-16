using System.ComponentModel.DataAnnotations;

namespace MAS_projekt_s22580.Models.Clients;

public class ClientStandard : BasicClient
{
    [Required]
    [Range(0, int.MaxValue)]
    public int LoyaltyPoints { get; set; }
}