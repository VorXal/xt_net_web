using System;
/// <summary>
/// Написать программу, которая заменяет все положительные элементы в трёхмерном массиве на нули.
/// Число элементов в массиве и их тип определяются разработчиком.
/// </summary>

namespace Task8
{
    class Program
    {
        static void NoPositiveInArray(int[,,] array)
        {
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                        if (array[i, j, k] > 0)
                            array[i, j, k] = 0;
                }
            }
        }

        static void Write3DArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                        Console.Write(" " + array[i, j, k] + " ");

                    Console.WriteLine(" ");
                }

                Console.WriteLine(" ");
            }
        }
        static void Main(string[] args)
        {
            int[,,] threeArrInit = {
                {
                    { -111, 112, -113 },
                    { 121, -122, 123 },
                    { -131, 132, -133 }
                },
                {
                    { -211, 212, -213 },
                    { 221, -222, 223 },
                    { -231, 232, -233 }
                }
            };

            Write3DArray(threeArrInit);
            Console.WriteLine("Now change!");
            NoPositiveInArray(threeArrInit);
            Write3DArray(threeArrInit);
            Console.ReadKey();
        }
    }
}
