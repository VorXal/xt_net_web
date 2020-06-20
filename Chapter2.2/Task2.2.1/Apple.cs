using System;

namespace Task2._2._1
{
    public class Apple : AbstractBonus, IDrawable
    {
        private string ICON = "A";
        //private string ICON = Char.ConvertFromUtf32(0x00B0);
        public Apple(int x, int y, int value)
            : base(x, y, value) { }

        public override string GetIcon() => ICON;

    }
}
