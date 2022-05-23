using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITS.Entities
{
    [Table("CompanyDetails")]
    public class CompanyDetails
    {
        [Key]
        [StringLength(50, MinimumLength = 3)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Address { get; set; }

        [Required]
        public double ContactNumber { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string CLogo { get; set; }
    }
}
