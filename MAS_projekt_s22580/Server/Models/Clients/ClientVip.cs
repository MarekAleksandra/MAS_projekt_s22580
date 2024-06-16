using System.ComponentModel.DataAnnotations;

namespace MAS_projekt_s22580.Models.Clients;

public class ClientVip : BasicClient
{
    [Required]
    [Range(0, int.MaxValue)]
    public int VipMembershipLevel { get; set; }
}