using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiDI003
{
    public interface IMyService
    {
        void Print();
    }

    public class MyService1 : IMyService
    {
        public void Print()
        {
            Console.WriteLine("MyService1.Print");
        }
    }
    public class MyService2 : IMyService
    {
        public void Print()
        {
            Console.WriteLine("MyService2.Print");
        }
    }
}
