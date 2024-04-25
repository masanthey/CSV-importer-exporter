using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using WA_Company_Personal_Accounting.Domain;
using WA_Company_Personal_Accounting.Domain.Entities;

namespace WA_Company_Personal_Accounting.Controllers
{
	public class CompanyController : Controller
	{
        private readonly DataManager dataManager;
		public CompanyController(DataManager dataManager) 
		{
			this.dataManager = dataManager;
		}

        public async Task<IActionResult> Edit(Guid id)
        {
            var entity = id == default ? new Company() : await dataManager.company.GetCompanyByIdAsync(id);
            return View(entity);
        }

        [HttpPost]
		public async Task<IActionResult> Edit(Company model) 
		{
            if (ModelState.IsValid)
            {            
                await dataManager.company.SaveCompanyAsync(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await dataManager.company.DeleteCompanyAsync(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
        }
    }
}
