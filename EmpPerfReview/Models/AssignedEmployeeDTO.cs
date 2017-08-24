using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpPerfReview.Models
{
    public class AssignedEmployeeDTO
    {
        public int Id { get; set; }
        public string ReviewDetail { get; set; } //from Review
        public int ReviewId { get; set; }
        public int AssignedEmployeeId { get; set; }
    }
}