using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EmpPerfReview.Common.Helpers.Enumeration;

namespace EmpPerfReview.Models
{
    public class EmployeeReviewDTO
    {
        public string Name { get; set; }
        public Role EmpRole { get; set; }
    }
}