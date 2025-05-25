using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppMonfIntensive.Models;

namespace WebAppMonfIntensive.ViewModels
{
    public class EmployeeWithDeptListViewModel
    {
        //Employee Data
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name="User Email")]
        [DataType(DataType.EmailAddress)]   //1)
        public string? Email { get; set; }  //2) string (text) - int (number) -bool (checkbox)
       
        public int Salary { get; set; }
        public string? ImageUrl { get; set; }
        public int DepartmentID { get; set; }


        //DeptList
        //[Required]
        public List<Department>? DeptList { get; set; }
    }
}
