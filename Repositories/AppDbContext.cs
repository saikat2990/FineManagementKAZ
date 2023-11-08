using Microsoft.EntityFrameworkCore;
using Repositories.Migrations;

namespace Repositories;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
       
    }
    public DbSet<Employee> Employee { get; set; }
}