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

        #region NEw
        public IActionResult New()
        {
            ViewBag.DeptList = context.Departments.ToList();
            return View("New");
        }
        [HttpPost]
        public IActionResult SaveNew(Employee empFromRequest)
        {
            if(empFromRequest.Name != null && empFromRequest.Salary>6000)
            {
                //add
                context.Employees.Add(empFromRequest);
                context.SaveChanges();
                return RedirectToAction("Index","Employee");
            }
            ViewData["DeptList"] = context.Departments.ToList();
            return View("New", empFromRequest);
        }

        #endregion


        #region Details
        //Employee/details/1?name=Ahmed
        public IActionResult Details(int id,string name) {
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
        #endregion

        #region Edit
        //Employee/Edit/1
        public IActionResult Edit(int id)
        {
            Employee empFromDb = context.Employees.FirstOrDefault(e=>e.Id==id);
            if (empFromDb != null)
            {
                //Declare ViewModel
                EmployeeWithDeptListViewModel empVM = new();
                //Mapping
                empVM.Email = empFromDb.Email;
                empVM.Id=empFromDb.Id;
                empVM.Name=empFromDb.Name;
                empVM.Salary=   empFromDb.Salary;
                empVM.DepartmentID = empFromDb.DepartmentID;
                empVM.ImageUrl= empFromDb.ImageUrl;

                empVM.DeptList = context.Departments.ToList();
                //Rerturn ViewModel
                return View("Edit", empVM);//Model ==Employee
            }
            return NotFound();
        }
        //Employee/SaveEdit/1?Name=as&Email=&Salary=&ImageUrl=&DepartmentID=
        [HttpPost]
        public IActionResult SaveEdit(EmployeeWithDeptListViewModel EmpFromReq)//id
        {
            if (EmpFromReq.Name != null)
            {
                //old ref
                Employee empFromDB = 
                    context.Employees.FirstOrDefault(e => e.Id == EmpFromReq.Id);
                //set new value
                empFromDB.Name= EmpFromReq.Name;
                empFromDB.Salary= EmpFromReq.Salary;
                empFromDB.ImageUrl= EmpFromReq.ImageUrl;
                empFromDB.DepartmentID= EmpFromReq.DepartmentID;
                empFromDB.Email= EmpFromReq.Email;
                //save changes
                context.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }

            EmpFromReq.DeptList = context.Departments.ToList();
            return View("Edit", EmpFromReq);
        }
        #endregion
    }
}

