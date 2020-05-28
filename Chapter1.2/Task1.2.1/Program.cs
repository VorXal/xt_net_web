using System;
/// <summary>
/// Напишите программу, которая определяет среднюю длину слова во введённой текстовой строке. 
/// Учтите, что символы пунктуации на длину слов влиять не должны. 
/// Не стоит искать каждый символ-разделитель вручную: пожалейте своё время и используйте стандартные методы классов String и Char.
/// </summary>

namespace Task1._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            float sum = 0;
            string inputString = "Викентий хорошо отметил день рождения: покушал пиццу, посмотрел кино, пообщался со студентами в чате";

            char[] chars = { ' ', ',', ':' };

            string[] words = inputString.Split(chars, StringSplitOptions.RemoveEmptyEntries);

            foreach (var i in words)
            {
                sum += i.Length;
            }

            float result = sum / (float)words.Length; //Ответ остается в виде дробного результата

            Console.WriteLine("Words: " + words.Length);
            Console.WriteLine("Average number of characters: " + result);
            Console.ReadKey();
        }
    }
}
