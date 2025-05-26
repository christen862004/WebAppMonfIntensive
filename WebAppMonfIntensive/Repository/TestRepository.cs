namespace WebAppMonfIntensive.Repository
{
    public class TestRepository : ITestREpository
    {
        public string Id { get ; set; }
        public TestRepository()
        {
            Id= Guid.NewGuid().ToString();//uniue
        }
    }
}
