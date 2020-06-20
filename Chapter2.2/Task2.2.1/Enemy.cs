using System;

namespace Task2._2._1
{
    public class Enemy : AbstractPlayer , IDrawable
    {
        private string ICON = "E";
        //private string ICON = Char.ConvertFromUtf32(0x00D7);
        public Enemy(int x, int y, int health)
            : base(x, y, health) { }

        public override string GetIcon() => ICON;

        public void Attack(Player player, Field field) //DANGER!!! Bad Code!!!
        {
            int[] temp = this.GetPosition();
            int[] temp1 = this.GetPosition();
            int[] temp2 = this.GetPosition();
            int[] temp3 = this.GetPosition();

            bool underAttackX = player.GetPosition()[0] == this.GetPosition()[0] + 1 ||
                                player.GetPosition()[0] == this.GetPosition()[0] - 1 ||
                                player.GetPosition()[0] == this.GetPosition()[0];

            bool underAttackY = player.GetPosition()[1] == this.GetPosition()[1] + 1 ||
                                player.GetPosition()[1] == this.GetPosition()[1] - 1 ||
                                player.GetPosition()[1] == this.GetPosition()[1];
            if (underAttackX && underAttackY)
            {
                player.ChangeHealthWithEffect(-this.Health);
            }

            temp[1]--;
            temp1[1]++;
            temp2[0]--;
            temp3[0]++;
            if(player.GetPosition()[1] < this.GetPosition()[1] && field.IsEmpty(temp))
            {
                this.ChangeY(-1);
            }
            else if (player.GetPosition()[1] > this.GetPosition()[1] && field.IsEmpty(temp1))
            {
                this.ChangeY(1);
            }
            else if(player.GetPosition()[0] < this.GetPosition()[0] && field.IsEmpty(temp2))
            {
                this.ChangeX(-1);
            }
            else if (player.GetPosition()[0] > this.GetPosition()[0] && field.IsEmpty(temp3))
            {
                this.ChangeX(1);
            }
        }
    }
}
