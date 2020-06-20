using System;

namespace Task2._2._1
{
    public class Player : AbstractPlayer, IDrawable
    {
        //private string ICON = Char.ConvertFromUtf32(0x00A9);
        private string ICON = "P";
        public Player(int x, int y, int health)
            :base(x, y, health) { }

        public void Attack(AbstractPlayer player)
        {
            if(this.GetPosition() == player.GetPosition())
            {
                if(this.Health > player.Health)
                {
                    ChangeHealthWithEffect(-player.Health);
                    
                }
            }
        }

        public override string GetIcon() => ICON;

        public void ChangePosition(ConsoleKey key, Field field)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    int[] temp = this.GetPosition();
                    temp[1]++;
                    if (this.GetPosition()[1] <= 23)
                    {
                        if (field.IsEmpty(temp))
                        {
                            ChangeY(1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can't move here");
                    }
                    break;
                case ConsoleKey.DownArrow:
                    temp = this.GetPosition();
                    temp[1]--;
                    if (this.GetPosition()[1] >= 2)
                    {
                        if (field.IsEmpty(temp))
                        {
                            ChangeY(-1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can't move here");
                    }
                    break;
                case ConsoleKey.RightArrow:
                    temp = this.GetPosition();
                    temp[0]++;
                    if (this.GetPosition()[0] <= 23)
                    {
                        if (field.IsEmpty(temp))
                        {
                            ChangeX(1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can't move here");
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    temp = this.GetPosition();
                    temp[0]--;
                    if (this.GetPosition()[0] >= 1)
                    {
                        if (field.IsEmpty(temp))
                        {
                            ChangeX(-1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can't move here");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
