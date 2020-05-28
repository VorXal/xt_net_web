using System;
/// <summary>
/// Для форматирования текста надписи можно использовать различные начертания: полужирное, курсивное и подчёркнутое, а также их сочетания. 
/// Предложите способ хранения информации о форматировании текста надписи и напишите программу, 
/// которая позволяет устанавливать и изменять начертание:
/// </summary>
namespace Task6
{

    class Program
    {
        [Flags] enum Style : byte
        {
            Bold        ,
            Italic      ,
            Underline   
        };

        static void Select()
        {
            Console.WriteLine($"1:     {Style.Bold}");
            Console.WriteLine($"2:     {Style.Italic}");
            Console.WriteLine($"3:     {Style.Underline}");
        }

        static void PrintChoice(int[] choice)
        {
            string output = "Selected Styles: ";


            if (choice[0] == 1) output += ("   " + Style.Bold);
            if (choice[1] == 1) output += ("   " + Style.Italic);
            if (choice[2] == 1) output += ("   " + Style.Underline);


            Console.WriteLine(output);
        }
        static void Main(string[] args)
        {
            //Style choice = Style.Bold | Style.Italic | Style.Underline;
            //Очень долго пытался сделать полностью только с enum, но не смог...
            //Эти 3 строки комментариев я оставляю в качестве признания своего поражения)))

            int[] choices = new int[3];

            while (true)
            {
                Select();

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        if (choices[0] == 0) choices[0] = 1;
                        else choices[0] = 0;
                        break;

                    case 2:
                        if (choices[1] == 0) choices[1] = 1;
                        else choices[1] = 0;
                        break;

                    case 3:
                        if (choices[2] == 0) choices[2] = 1;
                        else choices[2] = 0;
                        break;

                    default:
                        break;
                }

                PrintChoice(choices);
            }

        }
    }
}
