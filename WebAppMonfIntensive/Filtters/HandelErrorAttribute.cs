using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppMonfIntensive.Filtters
{
    public class HandelErrorAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //handel respnse
            //ContentResult result = new ContentResult();
            //result.Content=context.Exception.Message;
            ViewResult result = new ViewResult();
            result.ViewName = "Error";

            context.Result = result;
        }
    }
}
