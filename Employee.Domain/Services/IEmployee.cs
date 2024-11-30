using EM.Domain.Model;

namespace EM.Domain.Services
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> ListEmployees();
        Task AddEmployee(Employee entity);
        Task UpdateEmployee(Employee entity);
        Task<bool> DeleteEmployee(Employee entity);
    }
}
