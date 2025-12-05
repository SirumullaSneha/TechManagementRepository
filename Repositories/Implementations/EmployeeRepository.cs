
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
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee> GetByFields(int id, string name, string contact)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == id || e.Name == name || e.Contact == contact);
    }

    public Task<Employee> NoActiveAsync(int id)
    {
        var emp = _context.Employees.Find(id);
        if (emp != null){
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return Task.FromResult(emp);
        }
        else{
            return Task.FromResult<Employee>(null);        }
    }

    public Task<Employee> UpdateAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        _context.SaveChanges();
        return Task.FromResult(employee);
    }
}