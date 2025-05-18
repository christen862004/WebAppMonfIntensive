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
            dynamic x    = 10;
            dynamic y    = "ahmed";
            dynamic obj1 = new Student();
            //detect type at runtime throw exception
            x = obj1 + y;


            TestClass obj = new TestClass();
            obj.ID = 1;
        }
    }
}
