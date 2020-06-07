using System;

namespace Task2._1._2
{
    public class Point: IFigure
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Point point = (Point)obj;
            return (this.X == point.X && this.Y == point.Y);
        }

        public void GetInfo()
        {
            Console.WriteLine($"Class:{GetType().Name}, X:{X}, Y:{Y}");
        }

        public double GetArea()
        {
            Console.WriteLine("Point haven't area");
            return 0;
        }

        public static Point CreatePoint()
        {
            Console.WriteLine("Создаем точку...");
            Console.Write("Введите X: ");
            if(Double.TryParse(Console.ReadLine(), out double x))
            {
                Console.Write("Введите Y: ");
                if (Double.TryParse(Console.ReadLine(), out double y))
                {
                    return new Point(x, y);
                }
                else
                {
                    Console.WriteLine("String could not be parsed.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("String could not be parsed.");
                return null;
            }
            
        }
    }
}
