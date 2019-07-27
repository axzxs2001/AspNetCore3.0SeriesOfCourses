using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI002
{
    public interface IMyService
    {
        void Print(string method);
    }

    public class MyService : IMyService
    {
        public void Print(string method)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
    public class MyService1 : IMyService
    {
        int printCount;

        public void Print(string method)
        {
            printCount++;
            Console.WriteLine($"----{printCount} {method}  {DateTime.UtcNow}");
        }
    }

    public interface IYourService
    {
        void Print();
    }
    public class YourService : IYourService
    {

        private readonly IMyService _myService;
        public YourService(IMyService myService)
        {
            _myService = myService;
        }
        public void Print()
        {
            _myService.Print("YourService.Print");
        }
    }
}
