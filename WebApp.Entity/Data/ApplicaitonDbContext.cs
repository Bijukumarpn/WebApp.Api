using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Entity.Models;

namespace WebApp.Entity.Data
{
    public class ApplicaitonDbContext:IdentityDbContext
    {
        public ApplicaitonDbContext(DbContextOptions<ApplicaitonDbContext> option)
            :base(option)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasOne<Department>(s => s.Department)
            .WithMany(g => g.Employees)
            .HasForeignKey(s => s.DeptId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> EmployeeSet { get; set; }
        public DbSet<Department> DepartmentSet { get; set; }
    }
}
