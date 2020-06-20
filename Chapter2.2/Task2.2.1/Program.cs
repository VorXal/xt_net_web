using System;

namespace Task2._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(12, 24, 100);
            Enemy enemy = new Enemy(12, 17, 20);
            Field main = new Field();
            Console.WriteLine(main.IsEmpty(player.GetPosition()));
            //main.AddPlayer(player);
            //main.AddEnemy(enemy);
            //main.DrawField();
            //Console.WriteLine(main.IsEmpty(player.GetPosition()));


            //player.ChangePosition(Console.ReadKey().Key, main);
            main.AddPlayers(player, enemy);
            main.DrawField();
            while (true)
            {
                player.ChangePosition(Console.ReadKey().Key, main);
                Console.Clear();
                main.AddPlayers(player, enemy);
                main.DrawField();
            }
            main.DrawField();
            Console.ReadKey();
        }
    }
}
