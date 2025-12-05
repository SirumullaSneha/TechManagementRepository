public interface IPersonalRepository
{
    public Task<List<Personal>> GetAllAsync();
    public Task<Personal?> GetByIdAsync(int id);
    public Task<Personal?> GetByEmployeeIdAsync(int employeeId);
    public Task<Personal> AddAsync(Personal personal);
    public Task<Personal?> UpdateAsync(Personal personal);
    public Task<Personal?> NoActiveAsync(int id);
}