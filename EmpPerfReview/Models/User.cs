using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpPerfReview.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        // Foreign Key
        public int EmployeeId { get; set; }
    }
}