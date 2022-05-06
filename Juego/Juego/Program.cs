using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Juego
{
    class Program
    {
        public static ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        static Object player = new Object(Console.WindowWidth / 2, Console.WindowWidth / 2 - 2, 5, 0, colors[1]);
        static Object enemy = new Object(Console.WindowWidth / 2, Console.WindowWidth / 2, 0, 0, colors[4]);
        static Object powerUp = new Object(0,0,0, 0, colors[3]);
        static UI ui = new UI();
        
        
        static ConsoleKeyInfo cki = Console.ReadKey();
        public static Random generadorRandoms = new Random();

        static bool winCondition = false;
        public static bool attackMode = false;

        static void Main(string[] args)
        {
            Run();
        }

        static void MainLoop()
        {
            do
            {
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey();
                    CheckInput();
                }

                enemy.MoveEnemyOnePos();

                if(DetectCollisionPlayerAndPowerUp()) { attackMode = true; }

                if (DetectCollisionPlayerAndEnemy())
                {
                    if (attackMode == true)
                    {
                        enemy.RandomizePosition();
                        player.AddPoint();
                        attackMode = false;
                        powerUp.RandomizePosition();
                    }
                    else
                    {
                        player.RandomizePosition();
                        player.TakeDamage();
                    }                 
                }
                
                ui.DrawScreen(player, enemy, powerUp);

            } while (winCondition == false);
        }

        static void CheckInput()
        {
            if (cki.Key == ConsoleKey.UpArrow) { player.MoveUp(); }
            else if (cki.Key == ConsoleKey.DownArrow) { player.MoveDown(); }
            else if (cki.Key == ConsoleKey.LeftArrow) { player.MoveLeft(); }
            else if (cki.Key == ConsoleKey.RightArrow) { player.MoveRight(); }
        }

        static bool DetectCollisionPlayerAndEnemy()
        {
            if (player.x == enemy.x && player.y == enemy.y) { return true; }
            else return false;
        }

        static bool DetectCollisionPlayerAndPowerUp()
        {
            if (player.x == powerUp.x && player.y == powerUp.y) { return true; }
            else return false;
        }

        static void Run()
        {
            Console.CursorVisible = false;

            powerUp.RandomizePosition();

            MainLoop();
        }

    }
}
