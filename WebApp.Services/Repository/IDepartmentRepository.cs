using WebApp.Entity.Models;

namespace WebApp.Services.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartmentAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task AddDepartmentAsync(Department department);
        Task UpdateDepartmentAsyc(Department department);
        Task DeleteDepartmentAsync(int id);
    }
}
