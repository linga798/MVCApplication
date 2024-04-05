using CoreEFMVCApp.Models;
using CoreEFMVCApp.ViewModels;
using System.Collections;

namespace CoreEFMVCApp.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeViewModel> GetByIdAsync(int id);
        IQueryable<EmployeeViewModel> GetAllAsync();
        Task AddAsync(EmployeeViewModel employee);
        Task UpdateAsync(EmployeeViewModel employee);
        Task DeleteAsync(int id);
        Task<List<Department>> GetAllDepartments();
    }
}
