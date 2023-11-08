using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FineManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepositories _employeeRepositories;

        public EmployeeController(IEmployeeRepositories employeeRepositories)
        {
            _employeeRepositories = employeeRepositories;
        }

        [HttpPost("AddEmployees")]
        public async Task AddEmployees(List<Employee> employees)
        {
            try
            {
                await _employeeRepositories.AddEmployees(employees);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("GetEmployees")]
        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                var data =  await _employeeRepositories.GetAll();
                return data;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

   
}
