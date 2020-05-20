using System;
/// <summary>
/// Элемент двумерного массива считается стоящим на чётной позиции, 
/// если сумма номеров его позиций по обеим размерностям является чётным числом (например, [1,1] — чётная позиция, а [1,2] — нет). 
/// Определить сумму элементов массива, стоящих на чётных позициях.
/// </summary>

namespace Task10
{
    class Program
    {
        static void Write2DArray(int[][] array)
        {
            foreach (int[] row in array)
            {
                foreach (int number in row)
                {
                    Console.Write(" " + number + " ");
                }
                Console.WriteLine();
            }
        }
        
        static int GetSumEvenPositionInArray(int[][] array)
        {
            int SUM = 0;

            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < array[i].Length; j++)
                {
                    if ((i + j) % 2 == 0)
                        SUM += array[i][j];
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
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.WriteLine($"Enter Array[{i}][{j}]");
                    TwoDArray[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Write2DArray(TwoDArray);

            Console.WriteLine($"Even Position Sum = {GetSumEvenPositionInArray(TwoDArray)}");
            Console.ReadKey();
        }
    }
}
