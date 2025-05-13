using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Entity.Models
{
    [Table("tblEmployee")]
    public class Employee
    {
        [Key]//Primary Key
        public int Id { get; set; }
        [Display(Name = "Employee Name")]
        [Required]
        [StringLength(50)]
        public string EmpName { get; set; }
        [Range(18, 60)]
        public int Age { get; set; }
        public string Gender { get; set; }
        public int ManagerId { get; set; }
        public string? Location { get; set; }
        public int Salary { get; set; }
        public int DeptId { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public bool IsActive { get; set; }

        //[ForeignKey("DeptId")]
        public Department? Department { get; set; }

    }
}
