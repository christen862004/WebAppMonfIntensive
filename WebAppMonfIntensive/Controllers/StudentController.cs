using Microsoft.AspNetCore.Mvc;
using WebAppMonfIntensive.Models;

namespace WebAppMonfIntensive.Controllers
{
    public class StudentController : Controller
    {
        StudentBL StudentBl = new StudentBL();
        //Student/All
        public IActionResult All()
        {
            //get data from BL Model
            List<Student> studentList= StudentBl.GetAll();
            //send To View
            //return View("ShowAll");//go to view with name ShowAll ,Model Null
            return View("ShowAll",studentList);
            //go to view with name ShowAll ,Model type List<Student>

        }

        //Studednt/Details/1
        //Studednt/Details?ID=1
        public IActionResult Details(int id)
        {
            Student StudentModel= StudentBl.GetByID(id);
            if (StudentModel != null)
            {
                return View("Details", StudentModel);
                //View  : DEtails
                //Model : Student
            }
            return NotFound();
        }
    }
}
