using System;

namespace Task2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(2.4, 2.5, 5.6);
            Console.WriteLine(circle.GetCircumference());
            Round round = new Round();
            round.GetInfo();
        }
    }
}
