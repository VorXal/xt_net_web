using System;
using System.Text;

namespace Task1._2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            StringBuilder inputSB = new StringBuilder(Console.ReadLine());

            int index = 0;
            string[] inputString = inputSB.ToString().Split('.', '!', '?');
            
            for(int i = 0; i < inputString.Length - 1; i++)
            {
                if(i == 0)
                {
                    if (inputString[i][0] == Char.ToLower(inputString[i][0]))
                        inputSB[index] = Char.ToUpper(inputSB[index]);
                    index += inputString[i].Length + 2;
                }

                else
                {
                    if (inputString[i][1] == Char.ToLower(inputString[i][1]))
                        inputSB[index] = Char.ToUpper(inputSB[index]);
                    index += inputString[i].Length + 1;
                }

            }

            Console.WriteLine(inputSB);
            Console.ReadKey();
        }
    }
}
