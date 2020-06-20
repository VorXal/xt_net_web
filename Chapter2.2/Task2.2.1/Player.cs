using System;

namespace Task2._2._1
{
    public class Player : AbstractPlayer, IDrawable
    {
        //private string ICON = Char.ConvertFromUtf32(0x00A9);
        private readonly string ICON = "P";
        public Player(int x, int y, int health)
            : base(x, y, health) { }

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
                        if (field.IsEmpty(temp) || field.IsBonus(temp))
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
                    if (this.GetPosition()[1] >= 1)
                    {
                        if (field.IsEmpty(temp) || field.IsBonus(temp))
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
                    if (this.GetPosition()[0] <= 22)
                    {
                        if (field.IsEmpty(temp) || field.IsBonus(temp))
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
                        if (field.IsEmpty(temp) || field.IsBonus(temp))
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

        public string GetInfo() => $"Now player have {Health} HP";
    }
}
