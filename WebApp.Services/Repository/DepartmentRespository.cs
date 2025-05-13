using Microsoft.EntityFrameworkCore;
using WebApp.Entity.Data;
using WebApp.Entity.Models;

namespace WebApp.Services.Repository
{
    public class DepartmentRespository : IDepartmentRepository
    {
        private readonly ApplicaitonDbContext _context;

        public DepartmentRespository(ApplicaitonDbContext context)
        {
            _context = context;
        }

        public async Task AddDepartmentAsync(Department department)
        {
             _context.DepartmentSet.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.DepartmentSet.FindAsync(id);
            _context.DepartmentSet.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Department>> GetAllDepartmentAsync()
        {
           return  await _context.DepartmentSet.ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _context.DepartmentSet.FindAsync(id);
        }

        public async Task UpdateDepartmentAsyc(Department department)
        {
            _context.DepartmentSet.Update(department);
            await _context.SaveChangesAsync();
        }
    }
}
