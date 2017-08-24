using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpPerfReview.Models
{
    public class AssignedEmployee
    {
        public int Id { get; set; }
        // Foreign Keys
        public int ReviewId { get; set; }
        public int EmployeeId { get; set; }
    }
}