using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebApp.Entity.Data;
using WebApp.Entity.Dto;
using WebApp.Entity.Models;
using WebApp.Services.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(AuthenticationSchemes ="Basic")]
    [Authorize(AuthenticationSchemes ="Bearer")]
    public class EmployeeController(IEmployeeRepository repository,
        ILogger<EmployeeController> logger, IMemoryCache cache) : ControllerBase
    {
        public const string EmployeeCache = "EmployeeCache";

        // GET: api/<EmployeeController>
        [HttpGet("GetAllEmployees")]
        //[Route("GetAllEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllEmployees()
        {
            logger.LogInformation("Entered on GetAllEmployees");

            //try
            //{
            //    int[] ids = new int[3];
            //    ids[3] = 100;
            //}
            //catch (Exception ex)
            //{
            //    logger.LogError(ex.Message);               
            //}
            //if (!cache.TryGetValue(EmployeeCache, out List<EmployeeResponseDto> employeeData))
            //{
               
               var  employeeData = await repository.GetAllEmployeesAsync();

                //var cacheEntryOptions = new MemoryCacheEntryOptions()
                //    .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                //    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                //cache.Set(EmployeeCache, employeeData, cacheEntryOptions);
            //}

            return Ok(employeeData);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {

            var employee = await repository.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NoContent();
            }

            return Ok(employee);
        }

        // POST api/<EmployeeController>
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            await repository.AddEmployeesAsync(employee);

            return Ok();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("No content from the request");
            }

            await repository.UpdateEmployeesAsyc(employee);
            return Ok();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteDemployee(int id)
        {
            await repository.DeleteEmployeesAsync(id);

            return Ok();
        }
    }
}
