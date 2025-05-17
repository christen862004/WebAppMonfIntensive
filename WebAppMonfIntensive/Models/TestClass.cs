namespace WebAppMonfIntensive.Models
{
    public class TestClass
    {
        public static int counter { get; set; }
        public int ID { get; set; }
    }

    public class test()
    {
        public void tt()
        {
            TestClass obj = new TestClass();
            obj.ID = 1;
        }
    }
}
