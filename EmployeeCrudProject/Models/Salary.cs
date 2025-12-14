using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCrudProject.Models
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public int EmpId { get; set; }

        public decimal EmpSalary { get; set; }

        public Employee Employee { get; set; }
    }
}
