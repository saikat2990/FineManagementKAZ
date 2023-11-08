using Core.Dtos;
using Core.Entities;
using Core.Interfaces;

namespace Repositories.BaseRepository;

public class EmployeeRepositories:BaseRepository<Employee>, IEmployeeRepositories
{
    public EmployeeRepositories(AppDbContext context) : base(context)
    {
    }
    public async Task<List<Employee>> GetAll()
    {
        return await Task.Run(()=>All().ToList());
    }

    public async Task AddEmployees(List<Employee> employee)
    {
        try
        {
            await AddAsync(employee[0]);
            await SaveAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
} 
