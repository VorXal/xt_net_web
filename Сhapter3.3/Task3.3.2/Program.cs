using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! This app can help you to calculate type of string.");
            Console.WriteLine("For EXIT please insert 'EXIT'");
            while (true)
            {
                Console.Write("Please insert your string: ");
                string temp = Console.ReadLine();
                if (temp == "EXIT")
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Your string have type: {temp.GetStringType()}");
                }
            }
        }
    }
}
