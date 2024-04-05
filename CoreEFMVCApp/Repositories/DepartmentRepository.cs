using CoreEFMVCApp.Data;
using CoreEFMVCApp.Models;
using CoreEFMVCApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace CoreEFMVCApp.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbCOntext;

        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbCOntext = dbContext;
        }
        public async Task AddAsync(DepartmentViewModel department)
        {
            var newDepartment = new Department
            {
                Name = department.Name
            };
            await _dbCOntext.Departments.AddAsync(newDepartment);
            await _dbCOntext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Department department = await _dbCOntext.Departments.FindAsync(id);
            _dbCOntext.Departments.Remove(department);
            await _dbCOntext.SaveChangesAsync();
        }

        public async Task<List<DepartmentViewModel>> GetAllAsync()
        {
            var departments = await _dbCOntext.Departments.ToListAsync();
            List<DepartmentViewModel> departmentViewModels = new List<DepartmentViewModel>();
            foreach (var department in departments)
            {
                var departmentViewModel = new DepartmentViewModel
                {
                    DepartmentId = department.DepartmentId,
                    Name = department.Name
                };

                departmentViewModels.Add(departmentViewModel);
            }

            return departmentViewModels;
        }

        
        public async Task<DepartmentViewModel> GetByIdAsync(int id)
        {
            var dept = await _dbCOntext.Departments.FindAsync(id);
            DepartmentViewModel deptViewModel = new DepartmentViewModel
            {
                Name = dept.Name,
                DepartmentId = dept.DepartmentId

            };
            return deptViewModel;
        }
        public async Task UpdateAsync(DepartmentViewModel updatedDepartment)
        {
            var department = await _dbCOntext.Departments.FindAsync(updatedDepartment.DepartmentId);
            department.Name = updatedDepartment.Name;

            _dbCOntext.Departments.Update(department);
            await _dbCOntext.SaveChangesAsync();
        }
    }
}
