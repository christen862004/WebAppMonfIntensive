using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMonfIntensive.Models;
using WebAppMonfIntensive.Repository;
using WebAppMonfIntensive.ViewModels;

namespace WebAppMonfIntensive.Controllers
{
    //high level
    [Authorize]
    public class EmployeeController : Controller
    {
        int counter;
        //low level (DIP |IOC)
        IEmployeeRepository EmpRepository;
        IDepartmentRepository DeptRepository;
        //using Depency Inject DP
        public EmployeeController
            (IEmployeeRepository empRepo, IDepartmentRepository deptRepo)
        {
            EmpRepository = empRepo;
            DeptRepository= deptRepo;
        }
        //Employee
        //Employee/Index
        public IActionResult Index()
        {
            List<Employee> employees =EmpRepository.GetAll();
            return View("Index",employees);
            //Model ==> List<Employees>
        }

        //Employee/GreaterThan?Salary=80000&Name=Ahmed
        public IActionResult GreaterThan(int Salary,string Name)
       {
            if(Salary>7000)
            
                return Json(true);
            else
                return Json(false);
        }

        #region NEw

        public IActionResult New()
        {
            ViewBag.DeptList = DeptRepository.GetAll();
            return View("New");
        }
    
        [HttpPost]//Employee/SAveNEw :Post
        [ValidateAntiForgeryToken]//prevent any forieng req.
        public IActionResult SaveNew(Employee empFromRequest)
        {
            if(ModelState.IsValid==true)//valiadtion server side
            {
                try
                {
                    EmpRepository.Add(empFromRequest);
                    EmpRepository.Save();
                    return RedirectToAction("Index", "Employee");
                }catch(Exception ex)
                {
                    //handel send exption msg view 
                    //ModelState.AddModelError("DepartmentID", "Please Select Department");
                    ModelState.AddModelError("erro1", ex.InnerException.Message);
                }
            }
            ViewData["DeptList"] = DeptRepository.GetAll();
            return View("New", empFromRequest);
        }

        #endregion


        #region Edit
        //Employee/Edit/1
        public IActionResult Edit(int id)
        {
            Employee empFromDb = EmpRepository.GetById(id);
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

                empVM.DeptList = DeptRepository.GetAll();
                //Rerturn ViewModel
                return View("Edit", empVM);//Model ==Employee
            }
            return NotFound();
        }
      
        //Employee/SaveEdit/1?Name=as&Email=&Salary=&ImageUrl=&DepartmentID=
        [HttpPost]
        public IActionResult SaveEdit(EmployeeWithDeptListViewModel EmpFromReq)//id
        {
            //if(Request.Method=="POST")
            //{
            //    //execute
            //}
            //else
            //{
            //    return NotFound();
            //}

            if (EmpFromReq.Name != null)
            {
                //old ref
                Employee empFromDB = EmpRepository.GetById(EmpFromReq.Id);
                   //new Employee();//empFromDB.Id=EmpFromReq.Id;
                //set new value
                
                empFromDB.Name= EmpFromReq.Name;
                empFromDB.Salary= EmpFromReq.Salary;
                empFromDB.ImageUrl= EmpFromReq.ImageUrl;
                empFromDB.DepartmentID= EmpFromReq.DepartmentID;
                empFromDB.Email= EmpFromReq.Email;
                EmpRepository.Edit(empFromDB);
                //save changes
                EmpRepository.Save();
                return RedirectToAction("Index", "Employee");
            }

            EmpFromReq.DeptList = DeptRepository.GetAll();
            return View("Edit", EmpFromReq);
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

            Employee employee = EmpRepository.GetById(id);
            return View("Details", employee);
        }

        public IActionResult DetailsVM(int id)
        {
            //collect Data from different sourec
            string msg = "Message FRom Action";
            
            List<string> branches = new() { "Alex", "New Capital", "Samrt", "Monofia" };

            Employee empModel = EmpRepository.GetById(id);



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

    }
}

