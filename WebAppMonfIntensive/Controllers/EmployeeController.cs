using Microsoft.AspNetCore.Mvc;
using WebAppMonfIntensive.Models;

namespace WebAppMonfIntensive.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        //Employee
        //Employee/Index
        public IActionResult Index()
        {
            List<Employee> employees = context.Employees.ToList();
            return View("Index",employees);
            //Model ==> List<Employees>
        }
    }
}
