using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int EmployeeId { get; set; }
        public int AssignedEmployeeId { get; set; }
    }
}