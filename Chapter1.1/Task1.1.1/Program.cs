using System;

/// <summary>
/// Написать программу, которая определяет площадь прямоугольника со сторонами a и b. 
/// Если пользователь вводит некорректные значения (отрицательные или ноль), должно выдаваться сообщение об ошибке. 
/// Возможность ввода пользователем строки вида «абвгд» или нецелых чисел игнорировать.
/// </summary>
namespace Task1
{
    class Program
    {

        static float GetArea(int a, int b)
        {
            if (a <= 0 || b <= 0) throw new Exception("Введены некорректные значения"); //можно разделить на 2 отдельные проверки
            return a * b;
        }

        static float GetArea(float a, float b)
        {
            if (a <= 0 || b <= 0) throw new Exception("Введены некорректные значения"); //можно разделить на 2 отдельные проверки
            return a * b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetArea(5.6f, 7.5f));
            Console.WriteLine(GetArea(5, 6));
            Console.ReadKey();
        }
    }
}
