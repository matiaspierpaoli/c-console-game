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
        static Object player = new Object();
        static Object enemy = new Object();
        static Object powerUp = new Object();
        static UI ui = new UI();
        
        
        static ConsoleKeyInfo cki = Console.ReadKey();
        static public Random generadorRandoms = new Random();

        static bool winCondition = false;
        static public bool attackMode = false;

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

            player.x = Console.WindowWidth / 2;
            player.y = Console.WindowHeight / 2 - 2;

            enemy.x = Console.WindowWidth / 2;
            enemy.y = Console.WindowHeight / 2;

            powerUp.RandomizePosition();

            MainLoop();
        }

    }
}
