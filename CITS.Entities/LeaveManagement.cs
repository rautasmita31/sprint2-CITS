using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITS.Entities
{
    [Table("Leave")]
    public class LeaveManagement
    {
        [Key]
        public string EmailAddress { get; set; }

        [Required]
        public int EmployeeId { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime StartLeaveDate { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime EndLeaveDate { get; set; }
    }
}
