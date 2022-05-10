using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment5.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(1, long.MaxValue, ErrorMessage = "Account number cannot be negative or zero")]

        public int AccountNumber { get; set; }
        [StringLength(byte.MaxValue, MinimumLength = 2, ErrorMessage = "Minimum  length must be 2")]

        [Required(ErrorMessage = "Name must be specified")]
        public string Name { get; set; }
        [Range(500, long.MaxValue, ErrorMessage = "Minimum balance must be  500")]

        public double CurrentBalance { get; set; }

    }
}