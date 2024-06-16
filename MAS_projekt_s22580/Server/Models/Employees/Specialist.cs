using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_projekt_s22580.Models.Employees
{
    public class Specialist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Specialization { get; set; } = null!;

        [Range(4, int.MaxValue, ErrorMessage = "Years of Experience must be greater than 3.")]
        [Required]
        public int YearsOfExperience { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;
    }
}
