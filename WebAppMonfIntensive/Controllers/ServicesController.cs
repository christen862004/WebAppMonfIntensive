using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAppMonfIntensive.Filtters;
using WebAppMonfIntensive.Repository;

namespace WebAppMonfIntensive.Controllers
{
    //[HandelError]
    public class ServicesController : Controller
    {
        ITestREpository testRpo;
        
        public ServicesController(ITestREpository _testRepo)
        {
            testRpo = _testRepo;
            //IExceptionFilter
            //IActionFilter
        }
        
        public IActionResult Index()
        {
            try
            {
                ViewBag.Id = testRpo.Id;
                return View();
            }catch(Exception ex)
            {
                return Content(ex.Message);//handel result
            }
        }
        
        [HandelError]
        public IActionResult Method1()
        {
            throw new Exception("Method1 throw exception");
        }

        public IActionResult Method2()
        {
            throw new Exception("Method2 throw exception");
        }
    }
}
