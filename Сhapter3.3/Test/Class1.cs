using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Class1
    {
        public Class2[] objects = new Class2[5];

        public static Func<string, Class2> ReturnClass2 = null;
        public static Action<Class2> AppendClass2 = null;

        public void Print()
        {
            foreach(Class2 item in objects)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
