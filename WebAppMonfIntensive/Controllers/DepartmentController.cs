using Microsoft.AspNetCore.Mvc;
using WebAppMonfIntensive.Models;

namespace WebAppMonfIntensive.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            List<Department> DeptList = context.Departments.ToList();
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
                context.Departments.Add(deptFromReq);
                context.SaveChanges();
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
