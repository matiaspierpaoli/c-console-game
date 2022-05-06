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
        static Character player = new Character();
        static Character enemy = new Character();
        static UI points = new UI();
        
        static public int frameWidth = Console.WindowWidth - 5;
        static public int frameHeight = 20;
        static public int frameXBasePos = 1;
        static public int frameYBasePos = 5;

        static Point locationPoint = new System.Drawing.Point(frameXBasePos, frameYBasePos);
        static ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        
        static public ConsoleRectangle frame = new ConsoleRectangle(frameWidth, frameHeight, locationPoint, colors[14]);
        static ConsoleKeyInfo cki = Console.ReadKey();
        static public Random generadorRandoms = new Random();

        static bool winCondition = false;

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

                if (DetectCollisionPlayerAndEnemy())
                {
                    player.RandomizePosition();
                    player.TakeDamage();
                }


                Console.Clear();
                frame.Draw();
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
            Console.SetCursorPosition(player.x, player.y);
            player.Draw('X');
            Console.SetCursorPosition(enemy.x, enemy.y);
            enemy.Draw('@');

            Console.SetCursorPosition(Console.WindowWidth - 15, 1);
            points.DrawPoints();
            Console.SetCursorPosition(5, 1);
            player.DrawLives();

            Thread.Sleep(200);
        }

        static bool DetectCollisionPlayerAndEnemy()
        {
            if (player.x == enemy.x && player.y == enemy.y) { return true; }
            else return false;
        }

        static void Run()
        {
            Console.CursorVisible = false;

            player.x = Console.WindowWidth / 2;
            player.y = Console.WindowHeight / 2 - 2;

            enemy.x = Console.WindowWidth / 2;
            enemy.y = Console.WindowHeight / 2;




            MainLoop();
        }

    }
}
