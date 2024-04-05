using CoreEFMVCApp.Data;
using CoreEFMVCApp.Models;
using CoreEFMVCApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CoreEFMVCApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;  
        }
        public async Task AddAsync(EmployeeViewModel employee)
        {
            var newEmployee = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Gender = employee.Gender,
                Address = employee.Address,
                DepartmentId = employee.DepartmentId,
                IsActive = employee.IsActive,

            };
            await _dbContext.Employees.AddAsync(newEmployee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Employee employee = await _dbContext.Employees.FindAsync(id);
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<EmployeeViewModel> GetAllAsync()
        {
            var employees = _dbContext.Employees
            .Select(e => new EmployeeViewModel
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                DateOfBirth = e.DateOfBirth,
                Gender = e.Gender,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Address = e.Address,
                IsActive = e.IsActive,
                DepartmentId = e.DepartmentId
            });

            return employees;
        }

        public async Task<EmployeeViewModel> GetByIdAsync(int id)
        {
            var employee = await _dbContext.Employees .FindAsync(id);
            EmployeeViewModel employeeViewModel = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                DateOfBirth= employee.DateOfBirth,
                Address = employee.Address,
                IsActive = employee.IsActive,
                DepartmentId = employee.DepartmentId

            };

            return employeeViewModel;
        }

        //public async Task UpdateAsync(EmployeeViewModel updatedEmployee)
        //{
        //    var employee = await _dbContext.Employees.FindAsync(updatedEmployee.EmployeeId);
        //    employee.FirstName = updatedEmployee.FirstName;
        //    employee.LastName = updatedEmployee.LastName;
        //    employee.Gender = updatedEmployee.Gender;
        //    employee.Email = updatedEmployee.Email;
        //    employee.PhoneNumber = updatedEmployee.PhoneNumber;
        //    employee.DateOfBirth = updatedEmployee.DateOfBirth;
        //    employee.Address = updatedEmployee.Address;
        //    employee.IsActive = updatedEmployee.IsActive;
        //    employee.DepartmentId = updatedEmployee.DepartmentId;
        //    _dbContext.Employees.Update(employee);
        //    await _dbContext.SaveChangesAsync();

        //}

        public async Task UpdateAsync(EmployeeViewModel employeeUpdated)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeUpdated.EmployeeId);
            employee.FirstName = employeeUpdated.FirstName;
            employee.LastName = employeeUpdated.LastName;
            employee.Email = employeeUpdated.Email;
            employee.Gender = employeeUpdated.Gender;
            employee.DateOfBirth = employeeUpdated.DateOfBirth;
            employee.PhoneNumber = employeeUpdated.PhoneNumber;
            employee.Address = employeeUpdated.Address;
            employee.DepartmentId = employeeUpdated.DepartmentId;
            employee.IsActive = employeeUpdated.IsActive;
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _dbContext.Departments.ToListAsync();
        }
    }
}
