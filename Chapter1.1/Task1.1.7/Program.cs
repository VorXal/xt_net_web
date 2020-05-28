using System;
/// <summary>
/// Написать программу, которая генерирует случайным образом элементы массива (число элементов в массиве и их тип определяются разработчиком), 
/// определяет для него максимальное и минимальное значения, сортирует массив и выводит полученный результат на экран.
/// </summary>

namespace Task7
{
    class Program
    {

        static void WriteArray(int[] array)
        {
            Console.Write("Array:    ");

            foreach (int i in array)
                Console.Write($"{i} ");

            Console.WriteLine();
        }
        static void RandomArray(int[] array)
        {
            Random random = new Random();

            for(int i = 0; i < array.Length; i++)
                array[i] = random.Next(-100, 100);
        }
        static int FindMax(int[] array)
        {
            int MAX = array[0];
            for (int i = 0; i < array.Length; i++) if (array[i] > MAX) MAX = array[i];
            return MAX;
        }

        static int FindMin(int[] array)
        {
            int MIN = array[0];
            for (int i = 0; i < array.Length; i++) if (array[i] < MIN) MIN = array[i];
            return MIN;
        }

        static void SortArray(int[] array)
        {
            int temp = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter N (Recommend < 10): ");
            int[] array = new int[Convert.ToInt32(Console.ReadLine())];
            RandomArray(array);
            WriteArray(array);
            Console.WriteLine($"MIN: {FindMin(array)}");
            Console.WriteLine($"MAX: {FindMax(array)}");
            SortArray(array);
            WriteArray(array);
            Console.ReadKey();
        }
    }
}
