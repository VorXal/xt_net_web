using System;

namespace Task2._2._1
{
    public abstract class AbstractBonus: AbstractObject
    {
        public int Value { get; private set; }

        public void SetEffect(Player player) 
        {
            if(player.GetPosition()[0] == this.GetPosition()[0] && player.GetPosition()[1] == this.GetPosition()[1])
            {
                player.ChangeHealthWithEffect(Value);
            }   
        }

        public AbstractBonus(int x, int y, int value)
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

        }
    }
}
