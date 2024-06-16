using MAS_projekt_s22580.Models.Clients;
using MAS_projekt_s22580.Models.Employees;
using MAS_projekt_s22580.Server.Models.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_projekt_s22580.Models;

public class Person
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(40, ErrorMessage = "First Name cannot be longer than 40 characters")]
    [MinLength(2, ErrorMessage = "First Name cannot be shorter than 2 characters")]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(40, ErrorMessage = "Last Name cannot be longer than 40 characters")]
    [MinLength(2, ErrorMessage = "Last Name cannot be shorter than 2 characters")]
    public string LastName { get; set; } = null!;

    [Required]
    [DateValidator(ErrorMessage = "Birthdate cannot be in the future")]
    public DateTime Birthdate { get; set; }

    public int ClientId { get; set; }
    public int EmployeeId { get; set; }

    public virtual BasicClient Client { get; set; } = null!;
    public virtual Employee Employee { get; set; } = null!;

    [NotMapped]
    public int Age
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - Birthdate.Year;

            if (Birthdate.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}