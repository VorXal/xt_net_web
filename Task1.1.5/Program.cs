﻿using System;
/// <summary>
/// Если выписать все натуральные числа меньше 10, кратные 3 или 5, то получим 3, 5, 6 и 9. 
/// Сумма этих чисел будет равна 23. 
/// Напишите программу, которая выводит на экран сумму всех чисел меньше 1000, кратных 3 или 5
/// </summary>

namespace Task5
{
    class Program
    {
        static void SumOfNumbers()
        {
            int SUM = 0;
            for (int i = 0; i < 1000; i++) if (i % 5 == 0 || i % 3 == 0) SUM += i;
            Console.WriteLine(SUM);
        }
        static void Main(string[] args)
        {
            SumOfNumbers();
            Console.ReadKey();
        }
    }
}
