using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAppMonfIntensive.ViewModels;

namespace WebAppMonfIntensive.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel roleFromReq)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { 
                    Name=roleFromReq.RoleName
                };
                IdentityResult result=await  roleManager.CreateAsync(role);
                //save in db
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Create",roleFromReq);
        }
    }
}
