using System.ComponentModel.DataAnnotations;

namespace WebAppMonfIntensive.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        //public int xyz { get; set; }
        //public UniqueAttribute(int i)
        //{
            
        //}
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            string email = value.ToString();
            //emial unique per department
            //selected departemnt
            Employee EmpFromReq = (Employee) validationContext.ObjectInstance;

            ITIContext context = new ITIContext();
            Employee EmpFromDb = context.Employees
                .FirstOrDefault(e=>e.Email == email&& e.DepartmentID==EmpFromReq.DepartmentID);
           
            if (EmpFromDb == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Email Already Exist :("); 
        }
    }
}
