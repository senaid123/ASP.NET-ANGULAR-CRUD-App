using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly FullStackDbContext _context;
        public EmployeesController(FullStackDbContext fullStackDbContext)
        {
            _context = fullStackDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
           
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();
            await _context.Employees.AddAsync(employeeRequest);
            await _context.SaveChangesAsync();
            return Ok(employeeRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] Guid id)
        {
          var employee =  await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);   
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee employeeDetails)
        {
            var employee = await _context.Employees.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            employee.Name = employeeDetails.Name;
            employee.Email = employeeDetails.Email;
            employee.Phone = employeeDetails.Phone;
            employee.Salary = employeeDetails.Salary;
            employee.Department = employeeDetails.Department;

            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
