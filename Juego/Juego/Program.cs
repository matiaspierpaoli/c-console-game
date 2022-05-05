using System;
using System.Collections.Generic;
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
        static ConsoleKeyInfo cki = Console.ReadKey();

        static bool winCondition = false;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            player.SetX(0);
            player.SetY(0);

            enemy.SetX(Console.WindowWidth / 2);
            enemy.SetY(Console.WindowHeight / 2);


            

            MainLoop();           
        }

        static void MainLoop()
        {
            do
            {
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey();
                    player.CheckInput(cki);
                }

                enemy.GetRandomMove();



                DrawScreen();

            } while (winCondition == false);
        }

        static void DrawScreen()
        {
            Console.Clear();

            Console.SetCursorPosition(player.GetX(), player.GetY());
            player.Draw('X');
            Console.SetCursorPosition(enemy.GetX(), enemy.GetY());
            enemy.Draw('@');

            Console.SetCursorPosition(Console.WindowWidth - 5, 1);
            points.DrawPoints();
            Console.SetCursorPosition(5, 1);
            player.DrawLives();

            Thread.Sleep(200);
        }
    }
}
