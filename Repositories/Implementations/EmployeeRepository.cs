
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;
    public EmployeeRepository(ApplicationDbContext context)
    {
        context = _context;
    }
    public async Task<List<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }
}