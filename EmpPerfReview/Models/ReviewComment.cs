using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpPerfReview.Models
{
    public class ReviewComment
    {
        //[Required]
        public int Id { get; set; }
        public string Comment { get; set; }
        // Foreign Keys
        public int EmployeeId { get; set; }
        public int ReviewId { get; set; }
    }
}