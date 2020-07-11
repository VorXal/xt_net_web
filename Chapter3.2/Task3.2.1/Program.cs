using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            DynamicArray<int> dynamic = new DynamicArray<int>(new int[] { 1, 2});
            Console.WriteLine(dynamic.Capacity);

            Console.WriteLine(1);
            for(int j = 0; j < dynamic.Length; j++)
            {
                Console.WriteLine($"{j}: {dynamic[j]}");
            }
            dynamic.AddRange(arr);
            dynamic.AddRange(arr);
            dynamic.AddRange(arr);
            dynamic.AddRange(arr);
            dynamic.Insert(1000, 0);
            Console.WriteLine(2);
            int i = 0;
            foreach (var item in dynamic)
            {
                i++;
                Console.WriteLine($"{i} : {item}");
            }
            Console.WriteLine(dynamic.Capacity);


            Console.ReadKey();
        }
    }
}
