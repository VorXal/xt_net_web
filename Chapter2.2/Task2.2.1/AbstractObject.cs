using System;

namespace Task2._2._1
{
    public abstract class AbstractObject
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public int[] GetPosition() => new int[2] {X, Y};

        public AbstractObject(int x, int y)
        {
            if(x >= 0 || x <= 100)
            {
                X = x;
            }
            else
            {
                throw new Exception($"X out of field for this object, was: {x}");
            }
            if (y >= 0 || y <= 100)
            {
                Y = y;
            }
            else
            {
                throw new Exception($"Y out of field for this object, was: {y}");
            }
        }

        protected void ChangeX(int difference)
        {
            this.X += difference;
        }

        protected void ChangeY(int difference)
        {
            this.Y += difference;
        }

    }
}
