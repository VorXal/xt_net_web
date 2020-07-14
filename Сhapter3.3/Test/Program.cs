using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Class1.ReturnClass2 += CreateClass2;

            Class1.AppendClass2 += Append;

        }

        public static Class2 CreateClass2(string name)
        {
            return new Class2(name);
        }

        public static void Append(Class2 class2)
        {
            
        }

    }
}
