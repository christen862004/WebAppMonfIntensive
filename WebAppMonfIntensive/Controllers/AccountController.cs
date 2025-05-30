using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppMonfIntensive.Models;
using WebAppMonfIntensive.ViewModels;

namespace WebAppMonfIntensive.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController
            (UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        #region register
        public IActionResult register()
        {
            return View("register");
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> register(RegisterViewModel userFromREq)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName=userFromREq.UserName,
                    PasswordHash=userFromREq.Password,
                    Address=userFromREq.Address
                };
                IdentityResult result=await userManager.CreateAsync(user,userFromREq.Password);//ad b
                if (result.Succeeded)
                {
                    //assign user to Admin Role
                    await userManager.AddToRoleAsync(user, "Admin");

                    //create cookie
                    await signInManager.SignInAsync(user, false);//cookie presitien or not
                    //redierct any action nee to authorize
                    return RedirectToAction("Index", "Employee");
                }
                //return back manager cant save
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);//div
                }
            }
            return View("register",userFromREq);
        }
        #endregion

        #region login
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userFromDB=await userManager.FindByNameAsync(userFromReq.UserName);
                if(userFromDB != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userFromDB, userFromReq.Password);
                    if (found == true)
                    {
                        List<Claim> claims= new List<Claim>();
                        claims.Add(new Claim("Address", userFromDB.Address));

                        await signInManager.SignInWithClaimsAsync(userFromDB, userFromReq.RememberMe, claims);
                        //await signInManager.SignInAsync(userFromDB,userFromReq.RememberMe);
                        //id ,name ,email,role,Address
                        return RedirectToAction("Index", "Employee");
                    }

                }
                ModelState.AddModelError("", "Invalid Account");
            }
            return View("Login", userFromReq);
        }
        #endregion

        #region logout
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        #endregion
    }
}
