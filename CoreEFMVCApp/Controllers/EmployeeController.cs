using CoreEFMVCApp.Models;
using CoreEFMVCApp.Repositories;
using CoreEFMVCApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreEFMVCApp.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index(string searchString)
        {
            ViewData["Title"] = new Employee
            {
                FirstName = "test",
                LastName = "test",

            };
            var employees = _employeeRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(emp => emp.FirstName.Contains(searchString) || emp.LastName.Contains(searchString));
            }
            return View(employees);
        }
        //[HttpGet("{anything}")]
        public async Task<IActionResult> Add()
        {
            var departmentList = await _employeeRepository.GetAllDepartments();
            ViewBag.Departments = new SelectList(departmentList, "DepartmentId", "Name");
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(EmployeeViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            await _employeeRepository.AddAsync(model);
            return RedirectToAction("Index", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var departmentList = await _employeeRepository.GetAllDepartments();
            ViewBag.Departments = new SelectList(departmentList, "DepartmentId", "Name");

            var employee = await _employeeRepository.GetByIdAsync(id);
            return View(employee);
        }

        [HttpPost]
        
        public async Task<IActionResult> Edit(EmployeeViewModel employee)
        {

            if (!ModelState.IsValid)
            {
                return View(employee); // Return to the form with validation errors
            }
            //Update the database with modified details
            await _employeeRepository.UpdateAsync(employee);

            // Redirect to List all department page
            return RedirectToAction("Index", "Employee");
        } 

        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepository.DeleteAsync(id);
            return RedirectToAction("Index", "Employee");
        }
    }
}
