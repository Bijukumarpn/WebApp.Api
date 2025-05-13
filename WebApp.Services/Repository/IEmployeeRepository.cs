using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Entity.Dto;
using WebApp.Entity.Models;

namespace WebApp.Services.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeResponseDto>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task AddEmployeesAsync(Employee employee);
        Task UpdateEmployeesAsyc(Employee employee);
        Task DeleteEmployeesAsync(int id);
    }
}
