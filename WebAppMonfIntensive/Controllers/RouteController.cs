using Microsoft.AspNetCore.Mvc;

namespace WebAppMonfIntensive.Controllers
{
    public class RouteController : Controller
    {
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
