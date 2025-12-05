public interface IBankRepository
{
    public Task<List<BankDetails>> GetAllAsync();
    public Task<BankDetails?> GetByAccountNumber(string accountNumber);
    public Task<BankDetails?> AddAsync(BankDetails bankDetails);
    public Task<BankDetails?> UpdateAsync(BankDetails bankDetails);
    public Task<BankDetails?> NoActiveAsync(int id);
    
}