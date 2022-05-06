using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Juego
{
    class UI
    {
        static public int gameFrameWidth = Console.WindowWidth - 5;
        static public int gameFrameHeight = 20;
        static public int gameFrameXBasePos = 1;
        static public int gameFrameYBasePos = 5;

        static Point mainFrameLocationPoint = new System.Drawing.Point(gameFrameXBasePos, gameFrameYBasePos);
        static Point attackFrameLocationPoint = new System.Drawing.Point(Console.WindowWidth / 2 - 15, 1);
        static ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        static public ConsoleRectangle gameFrame = new ConsoleRectangle(gameFrameWidth, gameFrameHeight, mainFrameLocationPoint, colors[14]);
        static public ConsoleRectangle attackFrame = new ConsoleRectangle(20, 2, attackFrameLocationPoint, colors[7]);

        public static int points { get; set; }
        public void DrawPoints() { Console.WriteLine("Points: " + points); }
        public void DrawAttack() { Console.WriteLine("ATACK!");}

        public void DrawScreen(Object player, Object enemy, Object powerUp)
        {
            Console.Clear();
            gameFrame.Draw();

            Console.SetCursorPosition(player.x, player.y);
            player.Draw('X');
            Console.SetCursorPosition(enemy.x, enemy.y);
            enemy.Draw('@');

            Console.SetCursorPosition(Console.WindowWidth - 15, 1);
            DrawPoints();
            Console.SetCursorPosition(5, 1);
            player.DrawLives();

            if (Program.attackMode == true)
            {
                attackFrame.Draw();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 2);
                DrawAttack();
            }
            else
            {
                Console.SetCursorPosition(powerUp.x, powerUp.y);
                enemy.Draw('$');
            }

            Thread.Sleep(200);
        }



    }
}
