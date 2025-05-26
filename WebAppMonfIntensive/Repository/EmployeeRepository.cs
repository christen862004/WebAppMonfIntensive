using WebAppMonfIntensive.Models;

namespace WebAppMonfIntensive.Repository
{
    public class EmployeeRepository :IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository()
        {
            context = new ITIContext();
        }
        //Single reposibility
        public void Add(Employee obj)
        {
            context.Employees.Add(obj);
        }

        public void Delete(int id)
        {
            Employee emp=GetById(id);
            context.Employees.Remove(emp);
        }

        public void Edit(Employee obj)
        {
            Employee orgEmp=GetById(obj.Id);
            orgEmp.Name= obj.Name;
            orgEmp.Salary= obj.Salary;
            orgEmp.ImageUrl= obj.ImageUrl;
            orgEmp.Email= obj.Email;
            orgEmp.DepartmentID= obj.DepartmentID;
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id); 
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}


//Unit of Work (Create Context - Save - Rollback)