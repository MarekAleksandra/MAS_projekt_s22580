using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt_s22580.Shared.DTOs
{
    public class GuitarForList
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int NumberOfStrings { get; set; }

        [Required]
        public string FretboardMaterial { get; set; } = null!;

        [Required]
        public string BodyMaterial { get; set; } = null!;

        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public string Model { get; set; } = null!;

        [Required]
        public double Price { get; set; }
    }
}
