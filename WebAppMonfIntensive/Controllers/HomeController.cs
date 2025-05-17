using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMonfIntensive.Models;

namespace WebAppMonfIntensive.Controllers
{
    /*
     1) class sufix with Controller
     2) Class Inherit from Cotnroller
     */
    public class HomeController : Controller
    {
        /* Method call Action
         * 1) Must Be Public 
         * 2) Can't be Static
         * 3) Can't be Overload only in one case
         */

        //Home/ShowMsg
        //public  string ShowMsg()
        //{
        //    return "Hello from My fist Method";
        //}
        //home/ShowMsg
        public ContentResult ShowMsg()
        {
            //Logic
            //declare emp
            ContentResult result = new ContentResult();
            //fill data
            result.Content = "Hello from My fist Method";
            //return
            return result;
        }
        //Home/showView
        public ViewResult showView()
        {
            //logic
            //decalre
            ViewResult result = new ViewResult();
            //fill data
            result.ViewName = "View1";
            //return
            return result;
        }
        //home/showMix?id=10&name=ahmed
        //home/showMix/10?name=ahmedd
        public IActionResult ShowMix(int id,string name)
        {
            if (id % 2 == 0)
            {
                return View("View1");
            }
            else
            {
                return Content("Hello From Action");
            }
        }
      



        /*
         * 1) Content ==> ContentResult
         * 2) View    ==> ViewResult
         * 3) Json    ==> JsonReuslt                  --->ActionResult -->IActionresu
         * 4) NotFound==> NotFoundResult
         * 5) Empty   ==> EmptyResult
         * 6) NotAuth ==> AuthoutREsult
         * ......
         */




        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
