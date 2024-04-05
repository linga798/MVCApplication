using CoreEFMVCApp.Repositories;
using CoreEFMVCApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreEFMVCApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return View(departments);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Add(DepartmentViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);

            }
            await _departmentRepository.AddAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            return View(department);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(DepartmentViewModel department)
        {
            if(!ModelState.IsValid)
            {
                return View(department);
            }
           await _departmentRepository.UpdateAsync(department);
            return RedirectToAction("Index", "Department");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _departmentRepository.DeleteAsync(id);
            return RedirectToAction("Index", "Department");
        }
    }
}
