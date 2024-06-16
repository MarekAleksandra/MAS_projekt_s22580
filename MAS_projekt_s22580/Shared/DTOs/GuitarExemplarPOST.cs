using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt_s22580.Shared.DTOs
{
    public class GuitarExemplarPOST
    {
        [Required]
        public string SerialNumber { get; set; } = null!;
        [Required]
        public int IdGuitarType { get; set; }
        [Required]
        public int IdOrder { get; set; }
    }
}
