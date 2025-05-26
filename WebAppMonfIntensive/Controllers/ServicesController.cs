using Microsoft.AspNetCore.Mvc;
using WebAppMonfIntensive.Repository;

namespace WebAppMonfIntensive.Controllers
{
    public class ServicesController : Controller
    {
        ITestREpository testRpo;
        public ServicesController(ITestREpository _testRepo)
        {
            testRpo = _testRepo;
        }

        public IActionResult Index()
        {
            ViewBag.Id = testRpo.Id;
            return View();
        }
    }
}
