using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WA_Company_Personal_Accounting.Domain;
using WA_Company_Personal_Accounting.Domain.Entities;

namespace WA_Company_Personal_Accounting.Controllers
{
	public class EmployeeController : Controller
	{

        private readonly DataManager dataManager;
        public EmployeeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public async Task<IActionResult> Edit(Guid id)
		{
            var entity = id == default ? new Employee() : await dataManager.employee.GetEmployeeByIdAsync(id);
            return View(entity);
		}

        [HttpPost]
        public async Task<IActionResult> Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                await dataManager.employee.SaveEmployeeAsync(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await dataManager.employee.DeleteEmployeeAsync(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
        }

    }
}
