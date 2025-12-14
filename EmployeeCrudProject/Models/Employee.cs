using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudProject.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmpName { get; set; }

        [Required]
        public string Email { get; set; }

        
        public string PhoneNumber { get; set; }
    }
}
