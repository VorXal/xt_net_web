using System;

namespace Task2._2._1
{
    public class Apple : AbstractBonus, IDrawable
    {

        private string ICON = Char.ConvertFromUtf32(0x00B0);
        public Apple(int x, int y, int value, string type)
            : base(x, y, value, type) { }

        public string GetIcon() => ICON;

        public override void SetEffect(Player player)
        {
            if(player.GetPosition() == this.GetPosition())
            {
                player.ChangeHealthWithEffect(Value);
            }
        }

    }
}
