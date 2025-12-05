using System.ComponentModel.DataAnnotations.Schema;

public class Personal
{
    public int Id {get; set;}
    public string? FatherName {get; set;}
    public string? MotherName{get; set;}
    public int FamilyCount {get; set;}
    public string? MarriedStatus {get;set;}
    public string? HealthStatus {get; set;}
    [ForeignKey("Employee")]
    public int EmployeeId{get; set;}
    public Employee? Employee{get; set;}
    
}