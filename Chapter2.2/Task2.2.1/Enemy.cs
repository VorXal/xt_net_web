using System;

namespace Task2._2._1
{
    public class Enemy : AbstractPlayer , IDrawable
    {
        private string ICON = "E";
        //private string ICON = Char.ConvertFromUtf32(0x00D7);
        public Enemy(int x, int y, int health)
            : base(x, y, health) { }

        //public override void ChangePosition()
        //{
        //    throw new NotImplementedException();
        //}

        public override string GetIcon() => ICON;
    }
}
