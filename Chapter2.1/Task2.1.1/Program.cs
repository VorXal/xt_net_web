using System;


namespace Task2._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStringFromDLL customString = new CustomStringFromDLL("This string working from DLL");

            CustomString customString1 = new CustomString("This string working from class");

            customString.PrintCustomString();
            customString1.PrintCustomString();
        }
    }
}
