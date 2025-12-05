using Microsoft.EntityFrameworkCore;

public class BankRepository : IBankRepository
{
    private readonly ApplicationDbContext _context;
    public BankRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BankDetails?> AddAsync(BankDetails bankDetails)
    {
        // Ensure the referenced employee exists and avoid inserting a new Employee
        var emp = await _context.Employees.FindAsync(bankDetails.EmployeeId);
        if (emp == null)
        {
            return null;
        }

        // Detach any populated navigation property to avoid EF inserting it
        bankDetails.Employee = null;

        await _context.BankDetail.AddAsync(bankDetails);
        await _context.SaveChangesAsync();
        return bankDetails;
    }

    public async Task<List<BankDetails>> GetAllAsync()
    {
        return await _context.BankDetail.ToListAsync();
    }

    public async Task<BankDetails?> GetByAccountNumber(string accountNumber)
    {
        return await _context.BankDetail.FirstOrDefaultAsync(b => b.AccountNumber == accountNumber);
    }

    public async Task<BankDetails?> NoActiveAsync(int id)
    {
        var bank = await _context.BankDetail.FirstOrDefaultAsync(b => b.Id == id);
        if(bank != null)
        {
            _context.BankDetail.Remove(bank);
            await _context.SaveChangesAsync();
        }
        return bank;
    }

    public async Task<BankDetails?> UpdateAsync(BankDetails bankDetails)
    {
        // Prevent accidental new Employee insertion
        bankDetails.Employee = null;
        _context.BankDetail.Update(bankDetails);
        await _context.SaveChangesAsync();
        return bankDetails;
    }
}