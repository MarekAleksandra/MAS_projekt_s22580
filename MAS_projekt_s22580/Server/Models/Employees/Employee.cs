using MAS_projekt_s22580.Server.Models.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_projekt_s22580.Models.Employees;

public class Employee
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public static double MinSalary { get; set; } = 4000;
    [Required]
    [Range(0, double.MaxValue)]
    public double Salary { get; set; }
    [Required]
    [DateValidator]
    public DateTime EmploymentDate { get; set; }
    [Required]
    public int PersonId { get; set; }
    public virtual Person Person { get; set; } = null!;
    public int SellerId { get; set; }
    public int SpecialistId { get; set; }

    public virtual Seller Seller { get; set; } = null!;
    public virtual Specialist Specialist { get; set; } = null!;


}