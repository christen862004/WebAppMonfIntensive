namespace WebAppMonfIntensive.Models
{
    public class MyController
    {
        public void fun1(Action c)
        {
            int x = 10;
            c();
            x = 10;

        }
        public void fun2()
        {

        }
        public void test()
        {
            fun1(fun2);
        }


        private object data;

        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        public dynamic DyanimcData
        {
            get { return data; }
            set { data = value; }
        }
    }

    public class TestClass:List<string>
    {
        public static int counter { get; set; }
        public int ID { get; set; }
    }

    public class test()
    {
        public void tt()
        {

            MyController controller1 = new MyController();
            controller1.Data = 4;//boxing
            int xx=int.Parse(controller1.Data.ToString()); //unboxing
           
            controller1.Data = "ahmed";
            string name = controller1.Data.ToString();


            controller1.DyanimcData = 4;
            int x1 = controller1.DyanimcData; //Throw Exception




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
