using System;

namespace Task2._1._2
{
    public class Rectangle : AbstractFigure, IHasArea
    {
        public Point LeftTopPoint { get; private set; }

        private double width;
        public double Width { get => width;
            private set 
            {
                if(value >= 0)
                {
                    width = value;
                }
                else
                {
                    throw new Exception("Width can't be negative or zero");
                }
            } 
        }

        private double height;
        public double Height { get => height; 
            private set
            {
                if (value >= 0)
                {
                    height = value;
                }
                else
                {
                    throw new Exception("Height can't be negative or zero");
                }
            } 
        }

        public Rectangle(Point ltpoint, double width, double height)
        {
            LeftTopPoint = ltpoint;
            Width = width;
            Height = height;
        }

        public Rectangle()
        {
            LeftTopPoint = new Point(0, 0);
            width = 1;
            height = 1; 
        }

        public double GetArea()
        {
            return width * height;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Class: {GetType().Name}, " +
                              $"Left Top Point: ({LeftTopPoint.X};{LeftTopPoint.Y}), " +
                              $"Width: {Width}, Height: {Height}");
        }
    }
}
