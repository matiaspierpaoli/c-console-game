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
        
        static public int gameFrameWidth = Console.WindowWidth - 5;
        static public int gameFrameHeight = 20;
        static public int gameFrameXBasePos = 1;
        static public int gameFrameYBasePos = 5;

        static Point mainFrameLocationPoint = new System.Drawing.Point(gameFrameXBasePos, gameFrameYBasePos);
        static Point attackFrameLocationPoint = new System.Drawing.Point(Console.WindowWidth / 2 - 15, 1);
        static ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        static public ConsoleRectangle gameFrame = new ConsoleRectangle(gameFrameWidth, gameFrameHeight, mainFrameLocationPoint, colors[14]);
        static public ConsoleRectangle attackFrame = new ConsoleRectangle(20, 2, attackFrameLocationPoint, colors[7]);
        static ConsoleKeyInfo cki = Console.ReadKey();
        static public Random generadorRandoms = new Random();

        static bool winCondition = false;
        static bool attackMode = false;

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


                
                DrawScreen();

            } while (winCondition == false);
        }

        static void CheckInput()
        {
            if (cki.Key == ConsoleKey.UpArrow) { player.MoveUp(); }
            else if (cki.Key == ConsoleKey.DownArrow) { player.MoveDown(); }
            else if (cki.Key == ConsoleKey.LeftArrow) { player.MoveLeft(); }
            else if (cki.Key == ConsoleKey.RightArrow) { player.MoveRight(); }
        }

        static void DrawScreen()
        {
            Console.Clear();
            gameFrame.Draw();

            Console.SetCursorPosition(player.x, player.y);
            player.Draw('X');
            Console.SetCursorPosition(enemy.x, enemy.y);
            enemy.Draw('@');          

            Console.SetCursorPosition(Console.WindowWidth - 15, 1);
            ui.DrawPoints();
            Console.SetCursorPosition(5, 1);
            player.DrawLives();

            if(attackMode == true) 
            { 
                attackFrame.Draw();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 2);
                ui.DrawAttack();
            }
            else
            {
                Console.SetCursorPosition(powerUp.x, powerUp.y);
                enemy.Draw('$');
            }

            Thread.Sleep(200);
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
