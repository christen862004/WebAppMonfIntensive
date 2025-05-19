using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMonfIntensive.Models;
using WebAppMonfIntensive.ViewModels;

namespace WebAppMonfIntensive.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public EmployeeController()
        {
            
        }
        //Employee
        //Employee/Index
        public IActionResult Index()
        {
            List<Employee> employees = context.Employees.ToList();
            return View("Index",employees);
            //Model ==> List<Employees>
        }

        public IActionResult Details(int id) {
            //More extra  Info
            string msg = "Message FRom Action";
            int Temp = 30;
            List<string> branches = new() { "Alex", "New Capital", "Samrt", "Monofia" };

            ViewData["Message"]  = msg;
            ViewData["Temp"]     = 30;
            ViewData["Branches"] = branches;
            ViewData["Color"] = "red";

            //using ViewBag
            ViewBag.Age = 30;//==> ViewData["Age"]=30
            ViewBag.Color = "blue";

            Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);
            return View("Details", employee);
        }

        public IActionResult DetailsVM(int id)
        {
            //collect Data from different sourec
            string msg = "Message FRom Action";
            
            List<string> branches = new() { "Alex", "New Capital", "Samrt", "Monofia" };

            Employee empModel = context.Employees.FirstOrDefault(e => e.Id == id);



            //Decalre obj from ViewModel
            EmployeeWithMsgColorBranchListViewModel empViewModel = new ();

            //Mapping get data from source ==> DEtination (ViewModel)
            empViewModel.EmpId = empModel.Id;
            empViewModel.EmpName = empModel.Name;
            empViewModel.Branches = branches; ;
            empViewModel.Message = msg ;
            empViewModel.Temp = 10 ;
            empViewModel.Color = "red";


            //Send ViewModel to View
            return View("DetailsVM", empViewModel);
            //View  ==> DetailsVM
            //Model ==> EmployeeWithMsgColorBranchListViewModel
        }

    }
}
