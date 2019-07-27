using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiDI003
{
    public interface IDataBase
    {
        string DataBaseType { get; }
        void Print();
    }

    public class SqlDataBase : IDataBase
    {
        public string DataBaseType
        {
            get;
        }
        public SqlDataBase(string dataBaseType)
        {
            DataBaseType = dataBaseType;
        }
        public void Print()
        {
            Console.WriteLine($"这是一个：{DataBaseType}");
        }
    }
}
