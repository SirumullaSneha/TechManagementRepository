using Microsoft.AspNetCore.Mvc;

public interface IEmployeeRepository

{
    public Task<List<Employee>> GetAllAsync();
    public Task<Employee?> GetByFields(int id, string name, string contact);
    public Task<Employee> AddAsync(Employee employee);
    public Task<Employee?> UpdateAsync(Employee employee);
    public Task<Employee?> NoActiveAsync(int id);
    
}