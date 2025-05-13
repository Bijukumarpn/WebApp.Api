using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Entity.Models;
using WebApp.Services.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentController(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<DepartmentController>
        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var deprtment = await _repository.GetAllDepartmentAsync();
            return Ok(deprtment);
        }

        // GET api/<DepartmentController>/5
        [HttpGet("GetDepartmentById")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _repository.GetDepartmentByIdAsync(id);
            return Ok(department);
        }

        // POST api/<DepartmentController>
        [HttpPost("AddDepartment")]
        public async Task<IActionResult> AddDepartment([FromBody] Department department)
        {
             await _repository.AddDepartmentAsync(department);
            return Ok();
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("UpdateDepartment")]
        public async Task<IActionResult>  UpdateDepartment([FromBody] Department department)
        {
            await _repository.UpdateDepartmentAsyc(department);
            return Ok();
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _repository.DeleteDepartmentAsync(id);
            return Ok();
        }
    }
}
