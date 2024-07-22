using Istka_Group4_FoodOrdering_Entity.Services;
using Istka_Group4_FoodOrdering_Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Istka_Group4_FoodOrdering_WebMvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IAccountService _accountService;

        public RoleController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _accountService.GetAllRoles();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            string msg = await _accountService.CreateRoleAsync(model);
            if (msg == "OK")
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", msg);
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = await _accountService.GetAllUsersWithRole(id); //service katmanından geriye UsersInOrOutViewModel dönüyor.
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRoleViewModel model)
        {
            string msg = await _accountService.EditRoleListAsync(model);
            if (msg != "OK")
            {
                ModelState.AddModelError("", msg);
                return View(model);
            }

            return RedirectToAction("Edit", "Role", new { id = model.RoleId, area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var role = await _accountService.FindRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            string msg = await _accountService.DeleteRoleAsync(id);
            if (msg == "OK")
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", msg);
                var roles = await _accountService.GetAllRoles();
                return View("Index", roles);
            }
        }
    }
}
