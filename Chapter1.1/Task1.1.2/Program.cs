using System;
/// <summary>
/// Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N строк:
/// </summary>

namespace Task2
{
    class Program
    {
        static void BeautyTriangle(int N)
        {
            string stars = "";
            for(int i = 0; i < N; i++)
            {
                stars += "*";
                Console.WriteLine(stars);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter N: ");
            BeautyTriangle(Convert.ToInt32(Console.ReadLine()));
            Console.ReadKey();
        }
    }
}
