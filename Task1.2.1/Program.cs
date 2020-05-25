using System;

namespace Task1._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int words = 0;
            int letters = 0;

            string s1 = "Викентий хорошо отметил день рождения: покушал пиццу, посмотрел кино, пообщался со студентами в чате";

            for (int ctr = 0; ctr < s1.Length; ctr++)
            {
                if (Char.IsPunctuation(s1[ctr]) | Char.IsWhiteSpace(s1[ctr]))
                {
                    words++;
                    if (Char.IsPunctuation(s1[ctr]))
                        ctr++;
                }
                else
                    letters++;
            }

            Console.WriteLine(words);
            Console.WriteLine(letters);
            Console.ReadKey();
        }
    }
}
