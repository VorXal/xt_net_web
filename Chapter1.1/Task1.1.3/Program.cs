using System;
/// <summary>
/// Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N строк:
/// </summary>

namespace Task3
{
    class Program
    {
        static void AnotherBeautyTriangle(int N)
        {
            int k = 1;
            for (int i = 1; i <= N; i++)
            {
                for (int j = N; j >= k / 2 + 2; j--) Console.Write(' ');

                for (int j = 1; j <= k; j++) Console.Write('*');
             
                k += 2;
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter N: ");
            AnotherBeautyTriangle(Convert.ToInt32(Console.ReadLine()));
            Console.ReadKey();
        }
    }
}
