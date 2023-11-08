using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Repositories;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
       
    }
    public DbSet<Employee> Employee { get; set; }
}