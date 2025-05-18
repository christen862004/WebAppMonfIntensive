namespace WebAppMonfIntensive.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new() {
                new(){ Id=1,Name="Ahemd",Address="Alex",ImageUrl="m.png"},
                new(){ Id=2,Name="Asmaa",Address="Alex",ImageUrl="2.jpg"},
                new(){ Id=3,Name="Fatma",Address="Alex",ImageUrl="2.jpg"},
                new(){ Id=4,Name="AbdelWahab",Address="Alex",ImageUrl="m.png"},
                new(){ Id=5,Name="Omar",Address="Alex",ImageUrl="m.png"}
            };
        }

        public List<Student> GetAll()
        {
            return students;
        }
        public Student GetByID(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
