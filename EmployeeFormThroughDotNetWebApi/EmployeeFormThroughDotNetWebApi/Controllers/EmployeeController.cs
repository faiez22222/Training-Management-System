using EmployeeFormThroughDotNetWebApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeFormThroughDotNetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeDBContext _dbContext;
        public EmployeeController(EmployeeDBContext context)
        {
            _dbContext = context;
        }
        private List<EmployeeData> _employees = new List<EmployeeData>
        {
            new EmployeeData { Id = 1, Name = "John", Gender = "Male", Address = "USA" },
            new EmployeeData { Id = 2, Name = "Tom", Gender = "Male", Address = "UK" },
            new EmployeeData { Id = 3, Name = "Mary", Gender = "Female", Address = "CANADA" }
        };
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeData>>> Get()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public EmployeeData Get(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeData value)
        {
            if (value.Name != "")
            {
                _dbContext.Employees.Add(value);
                await _dbContext.SaveChangesAsync();
                return Ok(value);
            }
            else
            {
                return BadRequest("Name can not be empty");
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeeData value)
        {
            var existingEmployee = await _dbContext.Employees.FindAsync(id);
            Console.WriteLine("existinEmployee" , existingEmployee);
            if (existingEmployee == null)
            {
                return NotFound("Employee not found");
            } 
            existingEmployee.Name = value.Name; 
            existingEmployee.Gender = value.Gender; 
            existingEmployee.Address = value.Address;   
            _dbContext.Entry(existingEmployee).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound("No Employee with this id");
            }
            _dbContext.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return Ok($"this is {id} deleted");
        }
    }
}
