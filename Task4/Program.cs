using System;
/// <summary>
/// Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N треугольников:
/// </summary>

namespace Task4
{
    class Program
    {
        static void XMasTree(int N)
        {
            for (int i = 1; i <= N; i++)
            {
                for (int k = 1; k <= 2 * i; k += 2)
                {
                    for (int j = N; j >= k / 2 + 2; j--) Console.Write(' ');
                   
                    for (int j = 1; j <= k; j++) Console.Write('*');

                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter N: ");
            XMasTree(Convert.ToInt32(Console.ReadLine()));
            Console.ReadKey();
        }
    }
}
