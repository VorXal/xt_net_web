using System;

namespace Task2._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomString cs1 = new CustomString("Hello");
            CustomString cs2 = new CustomString("Hello!");
            cs1.PrintCustomString();
            cs2.PrintCustomString();
            Console.WriteLine(cs1.IsEqual(cs2));
            cs1.ConcatCustomString(cs2);
            cs1.PrintCustomString();
            CustomString cs3 = CustomString.ConcatCustomString(cs1, cs2);
            cs3.PrintCustomString();
            Console.WriteLine(CustomString.IsEqual(cs3, cs3));
            CustomString.PrintCustomString(cs3);
            Console.WriteLine(CustomString.FindCharInCustomString('0', cs3));
            Console.WriteLine(cs3.FindCharInCustomString('e'));
            char[] a = cs3.ReturnArray();
            Console.WriteLine(a);
            Console.WriteLine(CustomString.CountOfCharInCustomString('H', cs3));
            Console.ReadKey();
        }
    }
}
