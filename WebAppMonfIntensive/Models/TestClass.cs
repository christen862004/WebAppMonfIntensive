using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppMonfIntensive.Models
{

    public interface ISort
    {
        void Sort(int[] arr);
    }
    public class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //logic using BubbleSort Alg.
        }
    }
    //extend
    public class SelectSort:ISort
    {
        public void Sort(int[] arr) {
        
        }
    }

    public class ChrisSort : ISort
    {
        public void Sort(int[] arr)
        {
            
        }
    }

    //DIP (hign level ==> low level class)& IOC 
    public class MyList //depend sort on Bubble
    {
        int[] arr;
        ISort sortAlg;//(null)declare sort alg using bubble
        //dont create  but ask (constructor - fun parameter) give
        public MyList(ISort _sortAlg)
        {
            arr = new int[10];
            this.sortAlg = _sortAlg;
           // sortAlg = new BubbleSort();//still using bubblesort
        }

        public void SortList()
        {
            sortAlg.Sort(arr);
        }
    }

    public class MyController
    {
        public void fun3()
        {
            //lossly couple 
            MyList l1=new MyList(new BubbleSort());
            l1.SortList();//using BubbleSort
           
            MyList l2=new MyList(new SelectSort());
            l2.SortList();//using selectsort

            MyList l3=new MyList(new BubbleSort());

        }










        public void fun1(Action c)
        {
            //IEnumerable<Department> departments = new List<Department>();
            //IEnumerable<SelectListItem> items = departments;
            //int x = 10;
            //c();
            //x = 10;

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
