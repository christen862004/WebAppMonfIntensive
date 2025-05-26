using WebAppMonfIntensive.Models;

namespace WebAppMonfIntensive.Repository
{
    public class EmpFromMemoryRepository : IEmployeeRepository
    {
        public void Add(Employee obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Employee obj)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return new List<Employee>()
            { new Employee() { Id=1,Name="Ahmed"}, new Employee() { Id = 2, Name = "Alaa" } };
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
