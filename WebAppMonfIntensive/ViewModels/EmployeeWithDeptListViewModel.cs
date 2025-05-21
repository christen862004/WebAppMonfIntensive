using System.ComponentModel.DataAnnotations.Schema;
using WebAppMonfIntensive.Models;

namespace WebAppMonfIntensive.ViewModels
{
    public class EmployeeWithDeptListViewModel
    {
        //Employee Data
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public int Salary { get; set; }
        public string? ImageUrl { get; set; }
        public int DepartmentID { get; set; }


        //DeptList
        public List<Department> DeptList { get; set; }
    }
}
