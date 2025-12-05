using System.ComponentModel.DataAnnotations.Schema;

public class Project
{
    public int Id {get; set;}
    public string? Name {get; set;}
    public string? Code {get; set;}
    public string? Location {get; set;}
    public string? Manager {get; set;}
    [ForeignKey("Employee")]
    public int EmployeeId {get; set;}

    public Employee? Employee {get; set;}


}