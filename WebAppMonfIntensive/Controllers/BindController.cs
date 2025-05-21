using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebAppMonfIntensive.Models;

namespace WebAppMonfIntensive.Controllers
{
    public class BindController : Controller
    {
        #region actions take parameter Primitive Data

        /*
         <form action="/Bind/testPrimitive/1" method="get">
            <input name=age>
            <input name=name>
            <input name="color[0]">
        </form
         */
        #endregion
        //URL:/Bind/testPrimitive?age=10&name=ahmed&id=1
        //URL:/Bind/testPrimitive/1?age=10&name=ahmed
        //URL:/Bind/testPrimitive/1?color=red&color=blue
        public IActionResult testPrimitive(int age,string name,int id,string[] color)
        {
            return Content("OK");
        }


        //Collection List- Diction....
        //Bind/TestDic?name=Ahmed&Phones[Chriten]=123&Phones[Mohamed]=456
        public IActionResult TestDic(Dictionary<string,string> Phones,string name)
        {
            return Content("ok");
        }
      
        //Complex Object
        //Bind/TestObj/1?name=sd&ManagerName=Ahmed&Employees[0].Name=Christen
        public IActionResult TestObj(Department dept)
        //public IActionResult TestObj(int Id, string Name, string? ManagerName, List<Employee> Employees)
        {
            return Content("ok");
        }

    }
}
