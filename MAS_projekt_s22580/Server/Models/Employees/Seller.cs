using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_projekt_s22580.Models.Employees
{
    public class Seller 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int SalesTarget { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Knowledge Level must be between 1 and 10.")]
        public int KnowledgeLevel { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; } = null!;

    }
}
