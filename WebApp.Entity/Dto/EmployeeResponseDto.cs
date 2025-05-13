using System.ComponentModel.DataAnnotations;

namespace WebApp.Entity.Dto
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }
       
        [Required]
        [StringLength(50)]
        public string EmpName { get; set; }
        [Range(18, 60)]
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int ManagerId { get; set; }
        public string? Location { get; set; }
        public int Salary { get; set; }
        public string DeptName { get; set; }
    }
}
