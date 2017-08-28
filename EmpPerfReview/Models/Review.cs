using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpPerfReview.Models
{
    public class Review
    {
        //[Required]
        public int Id { get; set; }
        public string Detail { get; set; }
        // Foreign Keys
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        //[ForeignKey("AssignedEmployee")]
        //public int AssignedEmployeeId { get; set; }
        //public virtual Employee AssignedEmployee { get; set; }
    }
}