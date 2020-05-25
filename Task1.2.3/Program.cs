using System;
/// <summary>
/// Напишите программу, которая считает количество слов, начинающихся с маленькой буквы. 
/// Предлоги, союзы и междометия считаются словами. Финальную точку в предложении (как и любой другой знак) можно не учитывать.
/// </summary>
namespace Task1._2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string:");
            string inputString = Console.ReadLine();

            string lowerInputString = inputString.ToLower();

            string[] wordsInputString = inputString.Split(' ');
            string[] wordsLowerInputString = lowerInputString.Split(' ');
            int count = 0;

            for (int i = 0; i < wordsInputString.Length; i++)
                if (wordsInputString[i] == wordsLowerInputString[i])
                    count++;

            Console.WriteLine(count);
            Console.ReadKey();

        }
    }
}
