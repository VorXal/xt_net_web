using System;

namespace Task2._1._2
{
    public class Figure
    {
        public virtual double GetArea()
        {
            Console.WriteLine("\'Figure\' object can't have a square");
            return 0;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine("\'Figure\' object can't have Info");
        }
    }
}
