using Microsoft.EntityFrameworkCore;
using WebAppMonfIntensive.Models;

namespace WebAppMonfIntensive.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ITIContext context;

        public DepartmentRepository(ITIContext context)
        {
            this.context = context;
        }

        //CRUD ==>Model
        public void Add(Department obj)
        {
            context.Departments.Add(obj);
        }

        public void Delete(int id)
        {
            Department dept = GetById(id);
            context.Departments.Remove(dept);
        }

        public void Edit(Department obj)
        {
            Department deptOrg=GetById(obj.Id);
            deptOrg.Name = obj.Name;
            deptOrg.ManagerName = obj.ManagerName;
        }

        public List<Department> GetAll()
        {
            return context.Departments.AsNoTracking().ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
