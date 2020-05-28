using System;
using System.Text;
/// <summary>
/// Напишите программу, которая удваивает в первой введённой строке все символы, принадлежащие второй введённой строке.
/// </summary>
namespace Task1._2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input 1st string: ");
            StringBuilder firstString = new StringBuilder(Console.ReadLine());
            Console.WriteLine("Input 2nd string: ");
            string secondString = Console.ReadLine();

            char[] lettersSecondString;
            lettersSecondString = secondString.ToCharArray();

            for(int i = 0; i < firstString.Length; i++)
            {
                foreach(char letter in lettersSecondString)
                {
                    if(firstString[i] == letter)
                    {
                        firstString.Insert(i,letter);
                        i++;
                    }
                }
            }

            Console.WriteLine(firstString);
            Console.ReadKey();
        }
    }
}
