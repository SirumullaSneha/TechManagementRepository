using System.ComponentModel.DataAnnotations.Schema;

public class BankDetails
{
    public int Id{get; set;}
    public string? Name {get; set;}
    public string? AccountNumber {get; set;}
    public int Salary {get; set;}
    [ForeignKey("Employee")]
    public int EmployeeId{get; set;}
    public Employee? Employee {get; set;}
}