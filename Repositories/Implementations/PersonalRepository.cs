using Microsoft.EntityFrameworkCore;

public class PersonalRepository : IPersonalRepository
{
    private readonly ApplicationDbContext _context;
    public PersonalRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Personal>> GetAllAsync()
    {
        return await _context.Personals.ToListAsync();
    }

    public async Task<Personal?> GetByIdAsync(int id)
    {
        return await _context.Personals.FindAsync(id);
    }

    public async Task<Personal?> GetByEmployeeIdAsync(int employeeId)
    {
        return await _context.Personals.FirstOrDefaultAsync(p => p.EmployeeId == employeeId);
    }

    public async Task<Personal> AddAsync(Personal personal)
    {
        // prevent accidental insertion of Employee
        personal.Employee = null;
        await _context.Personals.AddAsync(personal);
        await _context.SaveChangesAsync();
        return personal;
    }

    public async Task<Personal?> UpdateAsync(Personal personal)
    {
        _context.Personals.Update(personal);
        await _context.SaveChangesAsync();
        return personal;
    }

    public async Task<Personal?> NoActiveAsync(int id)
    {
        var p = await _context.Personals.FindAsync(id);
        if (p != null)
        {
            _context.Personals.Remove(p);
            await _context.SaveChangesAsync();
            return p;
        }
        return null;
    }
}