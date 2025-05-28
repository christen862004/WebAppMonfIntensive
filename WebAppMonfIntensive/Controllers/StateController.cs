using Microsoft.AspNetCore.Mvc;

namespace WebAppMonfIntensive.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetSession(string name,int age)
        {
            //logic db condion
            HttpContext.Session.SetString("UserName", name);
            HttpContext.Session.SetInt32("Age", age);
            return Content("Session Data Save");
        }

        public IActionResult GetSession()
        {
            //logic
            string n =  HttpContext.Session.GetString("UserName");
            int? a   =  HttpContext.Session.GetInt32("Age");
            return Content($"Session name= {n} && Age ={a}");

        }


        public IActionResult SetCookie(string name, int age)
        {
            //logic
            //Session Cookie "Expiredd when session end"
            HttpContext.Response.Cookies.Append("Username", name);

            //Presistent Cookie 'Give Expiration Data'
            CookieOptions options=new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(1);
            HttpContext.Response.Cookies.Append("Age", age.ToString(), options);
            
            return Content("Cookie Save Success");
        }
        public IActionResult GetCookie()
        {
            //get from client
            string name= HttpContext.Request.Cookies["Username"];
            string age= HttpContext.Request.Cookies["Age"];
            return Content($"Name={name} \t Age= {age}");
        }
    }
}
