using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._3._1
{
    class Program
    {
        public static void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Hello! You need to create array, please select type.");
            Console.WriteLine("1) Int");
            Console.WriteLine("2) Double");
            Int32.TryParse(Console.ReadLine(), out int choose);
            switch (choose)
            {
                case 1 :
                    {
                        AddElements(CreateIntArray(ChooseLength()));
                        break;
                    }
                case 2:
                    {
                        AddElements(CreateDoubleArray(ChooseLength()));
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException($"You just had to select 1 or 2, when you select {choose}");
                    }
            }
        }

        public static void AddElements(int[] array)
        {
            Console.WriteLine("Now you need to add elements.");
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write($"[{i}] = ");
                array[i] = Int32.Parse(Console.ReadLine());
            }
            FunctionalArrayMenu(array);
        }

        public static void AddElements(double[] array)
        {
            Console.WriteLine("Now you need to add elements.");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"[{i}] = ");
                array[i] = Double.Parse(Console.ReadLine());
            }
            FunctionalArrayMenu(array);
        }

        public static void FunctionalArrayMenu(int[] array)
        {
            Console.Clear();
            Console.WriteLine("Now you can: ");
            Console.WriteLine("1) Find MAX element in array");
            Console.WriteLine("2) Find Average of array");
            Console.WriteLine("3) Find MaxRepeat element in array");
            Console.WriteLine("Other number is exit to create array");
            while (Int32.TryParse(Console.ReadLine(), out int choose))
            {
                switch (choose)
                {
                    case 1:
                        {
                            Console.WriteLine($"MAX element in array: {array.Max()}");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"Average of array: {array.Average()}");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"MaxRepeated element in array: {array.MaxRepeat()}");
                            break;
                        }
                    default:
                        {
                            PrintMainMenu();
                            break;
                        }
                }
            }
        }

        public static void FunctionalArrayMenu(double[] array)
        {
            Console.Clear();
            Console.WriteLine("Now you can: ");
            Console.WriteLine("1) Find MAX element in array");
            Console.WriteLine("2) Find Average of array");
            Console.WriteLine("3) Find MaxRepeat element in array");
            Console.WriteLine("Other number is exit to create array");
            while (Int32.TryParse(Console.ReadLine(), out int choose))
            {
                switch (choose)
                {
                    case 1:
                        {
                            Console.WriteLine($"MAX element in array: {array.Max()}");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"Average of array: {array.Average()}");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"MaxRepeated element in array: {array.MaxRepeat()}");
                            break;
                        }
                    default:
                        {
                            PrintMainMenu();
                            break;
                        }
                }
            }
        }

        public static int ChooseLength()
        {
            Console.Clear();
            Console.WriteLine("Please, choose length of array");
            Console.Write($"Length: ");
            int length;
            while (!Int32.TryParse(Console.ReadLine(), out length))
            {
                Console.WriteLine("Incorrect input");
                Console.WriteLine("Please, choose length of array one more time");
                Console.Write($"Length: ");
            }
            return length;
        }

        public static int[] CreateIntArray(int length)
        {
            return new int[length];
        }

        public static double[] CreateDoubleArray(int length)
        {
            return new double[length];
        }

        static void Main(string[] args)
        {
            PrintMainMenu();
        }
    }
}
