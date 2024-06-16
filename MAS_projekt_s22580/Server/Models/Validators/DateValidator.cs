using System.ComponentModel.DataAnnotations;

namespace MAS_projekt_s22580.Server.Models.Validators
{
    public class DateValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                if (date > DateTime.Now)
                {
                    return false;
                }
            }
            return true; 
        }
    }
}
