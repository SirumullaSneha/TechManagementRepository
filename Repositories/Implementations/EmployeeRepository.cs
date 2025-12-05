
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;
    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Employee> AddAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetByFields(int id, string name, string contact)
    {
        // Find by any provided field (id, name or contact). Returns first match or null.
        return await _context.Employees
            .FirstOrDefaultAsync(e => (id > 0 && e.Id == id) || (!string.IsNullOrEmpty(name) && e.Name == name) || (!string.IsNullOrEmpty(contact) && e.Contact == contact));
    }

    public async Task<Employee?> NoActiveAsync(int id)
    {
        var emp = await _context.Employees.FindAsync(id);
        if (emp != null)
        {
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return emp;
        }
        return null;
    }

    public async Task<Employee?> UpdateAsync(Employee employee)
    {
        // Ensure EF tracks the entity correctly
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        return employee;
    }
}