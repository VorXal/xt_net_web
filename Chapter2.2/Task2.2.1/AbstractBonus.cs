using System;

namespace Task2._2._1
{
    public abstract class AbstractBonus: AbstractObject
    {
        public int Value { get; private set; }
        public string Type { get; private set; }

        enum TypeBonus
        {
            None,
            Good,
            Bad
        }

        public abstract void SetEffect(Player player);

        public AbstractBonus(int x, int y, int value, string type)
            :base(x, y)
        {
            if(value >= 0)
            {
                Value = value;
            }
            else
            {
                throw new Exception($"Value of bonus can't be negative, was: {value}");
            }
            if(type == TypeBonus.Good.ToString() || type == TypeBonus.Bad.ToString())
            {
                Type = type;
            }
            else
            {
                throw new Exception($"Invalid type of bonus");
            }

        }
    }
}
