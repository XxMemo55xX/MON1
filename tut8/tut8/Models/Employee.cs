using System.ComponentModel.DataAnnotations;

namespace tut8.Models
{

    public class Department
    {
        [Key]
        public int IdDepartment { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }


    }
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public Department? Department { get; set; }


    }
}
