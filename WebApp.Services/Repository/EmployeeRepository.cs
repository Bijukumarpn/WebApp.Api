using Microsoft.EntityFrameworkCore;
using WebApp.Entity.Data;
using WebApp.Entity.Dto;
using WebApp.Entity.Models;

namespace WebApp.Services.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicaitonDbContext _context;

        public EmployeeRepository(ApplicaitonDbContext context)
        {
            _context = context;
        }

        public async Task AddEmployeesAsync(Employee employee)
        {
            _context.EmployeeSet.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeesAsync(int id)
        {
            var employee = await _context.EmployeeSet.FindAsync(id);
            _context.EmployeeSet.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Result<List<EmployeeResponseDto>>> GetAllEmployeesAsync()
        {
            var result = new Result<List<EmployeeResponseDto>>();

            var employees = await (from emp in _context.EmployeeSet
                                   join dept in
                                   _context.DepartmentSet on emp.DeptId equals dept.DeptId
                                   select new EmployeeResponseDto
                                   {
                                       Id = emp.Id,
                                       EmpName = emp.EmpName,
                                       Age = emp.Age,
                                       Gender = emp.Gender,
                                       DeptName = dept.DeptName,
                                       Salary = emp.Salary,
                                       Location = emp.Location,
                                       Email = emp.Email
                                   }).ToListAsync();

            if (employees == null || employees.Count == 0)
            {
                result.Errors.Add(new Errors { Id = 1, ErrorCode = 100, ErrorMessage = "No Employees Found" });
            }

            result.Response = employees;

            return result;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.EmployeeSet.FindAsync(id);
            return employee;
        }

        public async Task UpdateEmployeesAsyc(Employee employee)
        {
            try
            {
                _context.EmployeeSet.Update(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
