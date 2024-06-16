using MAS_projekt_s22580.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt_s22580.Shared.DTOs
{
    public class OrderForList
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public string OrderNumber { get; set; } = string.Empty;
    }
}
