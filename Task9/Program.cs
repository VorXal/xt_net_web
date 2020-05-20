using System;
/// <summary>
/// Написать программу, которая определяет сумму неотрицательных элементов в одномерном массиве. 
/// Число элементов в массиве и их тип определяются разработчиком.
/// </summary>

namespace Task9
{
    class Program
    {
        static void Write2DArray(int[][] array)
        {
            foreach(int[] row in array)
            {
                foreach(int number in row)
                {
                    Console.Write(" " + number + " ");
                }
                Console.WriteLine();
            }
        }

        static int GetNonNegativeSum(int[][] array)
        {
            int SUM = 0;

            foreach (int[] row in array)
            {
                foreach (int number in row)
                {
                    if (number > 0)
                        SUM += number;
                }
            }
            return SUM;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter M: ");
            int M = Convert.ToInt32(Console.ReadLine());

            
            int[][] TwoDArray = new int[N][];
            for (int i = 0; i < N; i++)
                TwoDArray[i] = new int[M];


            Console.Clear();
            Console.WriteLine("Enter Array: ");
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < M; j++)
                {
                    Console.WriteLine($"Enter Array[{i}][{j}]");
                    TwoDArray[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Write2DArray(TwoDArray);

            Console.WriteLine($"Non Negative Sum = {GetNonNegativeSum(TwoDArray)}");
            Console.ReadKey();
        }
    }
}
