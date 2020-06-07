using System;

namespace Task2._1._2
{
    class Square : Rectangle, IFigure
    {
        public Square(Point ltpoint, double size)
            : base(ltpoint, size, size) { }

        public static Square CreateSquare()
        {
            Console.WriteLine("Создаем квадрат...");
            Console.WriteLine("Введите левую верхнюю точку: ");
            Point ltp = Point.CreatePoint();
            double size = 0;
            Console.Write("Введите размер: ");
            if (Double.TryParse(Console.ReadLine(), out double out_size))
            {
                size = out_size;
                return new Square(ltp, size);
            }
            else
            {
                Console.WriteLine("String could not be parsed.");
                return null;
            }
        }
    }
}
