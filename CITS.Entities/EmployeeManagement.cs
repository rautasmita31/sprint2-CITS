using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITS.Entities
{

    [Table("EmployeeManagement")]
    public class EmployeeManagement
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string ContactAddress { get; set; }

        [Required]
        public double MobileNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateofJoining { get; set; }

        [Required]
        public double BasicSalary { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Profession { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Resume { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string OfferLetter { get; set; }
    }

}