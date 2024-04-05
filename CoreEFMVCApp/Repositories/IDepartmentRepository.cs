using CoreEFMVCApp.Models;
using CoreEFMVCApp.ViewModels;

namespace CoreEFMVCApp.Repositories
{
    public interface IDepartmentRepository
    {
        Task<DepartmentViewModel> GetByIdAsync(int id);
        Task<List<DepartmentViewModel>> GetAllAsync();
        Task AddAsync(DepartmentViewModel department);
        Task UpdateAsync(DepartmentViewModel department);
        Task DeleteAsync(int id);
    }
}
