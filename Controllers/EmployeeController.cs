using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _employeeRepository.GetAllAsync();
        return Ok(employees);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
    {
        var newEmployee = await _employeeRepository.AddAsync(employee);
        return CreatedAtAction(nameof(GetAllEmployees), new { id = newEmployee.Id }, newEmployee);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
    {
        var updatedEmployee = await _employeeRepository.UpdateAsync(employee);
        return Ok(updatedEmployee);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var deletedEmployee = await _employeeRepository.NoActiveAsync(id);
        if (deletedEmployee == null)
        {
            return NotFound();
        }
        return Ok(deletedEmployee);
    }
}