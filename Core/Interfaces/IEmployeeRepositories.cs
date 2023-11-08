using Core.Dtos;
using Core.Entities;
using Core.Interfaces.Repositories.Base;

namespace Core.Interfaces;

public interface IEmployeeRepositories : IBaseRepository<Employee>
{
    Task<List<Employee>> GetAll();
    Task AddEmployees(List<Employee> employee);
}