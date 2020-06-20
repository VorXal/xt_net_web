using System;

namespace Task2._2._1
{
    public class Block : AbstractObject
    {
        private string ICON = "*";
        public Block(int x, int y)
            : base(x, y) { }

        public override string GetIcon() => ICON;
    }
}
