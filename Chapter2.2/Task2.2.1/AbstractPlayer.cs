using System;

namespace Task2._2._1
{
    public abstract class AbstractPlayer: AbstractObject
    {
        public int Health { get; private set; }

        public AbstractPlayer(int x, int y, int health)
            : base(x, y)
        {
            if(health > 0)
            {
                Health = health;
            }
            else
            {
                throw new Exception($"Health can't be negative, was: {health}");
            }

        }

        public void ChangeHealthWithEffect(int change)
        {
            Health += change;
        }

    }
}
