using MAS_projekt_s22580.Models;
using System.ComponentModel.DataAnnotations;


namespace MAS_projekt_s22580.Shared.DTOs
{
    public class OrderDetails
    {
        [Required]
        public int Id { get; set;}
        [Required]
        public string OrderNumber { get; set;} = string.Empty;
        [Required]
        public string ClientFirstName { get; set; } = string.Empty;
        [Required]
        public string ClientLastName { get; set; } = string.Empty;
        [Required]
        public int ClientID { get; set; }
        [Required]
        public Status Status { get; set; }


    }
}
