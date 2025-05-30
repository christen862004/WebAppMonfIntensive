using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAppMonfIntensive.Controllers
{
    public class RouteController : Controller
    {
        //[Authorize]
        public IActionResult Welcome()
        {
            //autho : welomce name
            if (User.Identity.IsAuthenticated == true)
            {
                //anoumous : Wleome Gust
                string name = User.Identity.Name;

                Claim IdClaim= User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
               
                Claim AddClaim = User.Claims.FirstOrDefault(c => c.Type == "Address");

                return Content($"Wlcome User Account Loged  {name} \t id={IdClaim.Value}");
            }
            return Content("Welcome Gust");
        }
        




        [Route("r1/{age:int}/{name?}",Name ="route1")]//only route 
        public IActionResult Method1(int age,string name)
        {
            return Content("Method1");
        }
        //Route/MEthod2
        public IActionResult Method2()
        {
            return Content("Method2");
        }
    }
}
