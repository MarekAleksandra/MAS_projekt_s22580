using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MAS_projekt_s22580.Models.Clients
{
    public class PhoneNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Number { get; set; } = null!;

        [Required]
        public int ClientId { get; set; }

        public virtual BasicClient Client { get; set; } = null!;
    }
}
