using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(){ }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }

    public DbSet<Employee> Employees {get; set;}
    public DbSet<BankDetails> BankDetail {get; set;}
    public DbSet<Personal> Personals {get; set;}
    public DbSet<Project> Projects {get; set;}
}