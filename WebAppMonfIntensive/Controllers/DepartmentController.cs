using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using WebAppMonfIntensive.Models;
using WebAppMonfIntensive.Repository;

namespace WebAppMonfIntensive.Controllers
{
    //[Authorize]
    public class DepartmentController : Controller
    {
        // ITIContext context = new ITIContext();
        IDepartmentRepository DeptRepository;
        public DepartmentController(IDepartmentRepository deptRepo)
        {
            DeptRepository = deptRepo;// new DepartmentRepository();
        }
       // [AllowAnonymous]//defualt filtter
        public IActionResult Index()
        {
            List<Department> DeptList = DeptRepository.GetAll();
            return View("Index",DeptList);
            //view : Index 
            //Model: List<Department>
        }

        public IActionResult New()
        {
            return View("New");//Model null
        }

        //by default mvcv action can handel get | Post Req
        //Department/SaveNew?Name=SD&ManagerName=Ahmed
        [HttpPost]
        public IActionResult SaveNew(Department deptFromReq)//(string Name,string ManagerName)
        {
            if (deptFromReq.Name != null && deptFromReq.ManagerName != null)
            {
                DeptRepository.Add(deptFromReq);
                DeptRepository.Save();
                return RedirectToAction("Index", "Department");//Problem
            }
            return View("New", deptFromReq);//view NAme "New" + Model ==>Department
            //if (Request.Method == "POST")
            //{
            //}
            //return NotFound();
        }
    }
}
