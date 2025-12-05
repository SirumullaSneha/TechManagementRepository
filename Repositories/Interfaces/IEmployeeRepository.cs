using Microsoft.AspNetCore.Mvc;

public interface IEmployeeRepository

{
    public Task<List<Employee>> GetAllAsync();
    
}