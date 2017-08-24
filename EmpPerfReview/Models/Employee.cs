using System.ComponentModel.DataAnnotations;
using static EmpPerfReview.Common.Helpers.Enumeration;

namespace EmpPerfReview.Models
{
    public class Employee
    {
        //[Required]
        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string EmpRole { get; set; } //change to enum
    }
}