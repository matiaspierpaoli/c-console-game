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
        public static int gameFrameWidth = Console.WindowWidth - 5;
        public static int gameFrameHeight = 20;
        public static int gameFrameXBasePos = 1;
        public static int gameFrameYBasePos = 5;

        static Point mainFrameLocationPoint = new System.Drawing.Point(gameFrameXBasePos, gameFrameYBasePos);
        static Point attackFrameLocationPoint = new System.Drawing.Point(Console.WindowWidth / 2 - 15, 1);
       

        static public ConsoleRectangle gameFrame = new ConsoleRectangle(gameFrameWidth, gameFrameHeight, mainFrameLocationPoint, Program.colors[14]);
        static public ConsoleRectangle attackFrame = new ConsoleRectangle(20, 2, attackFrameLocationPoint, Program.colors[9]);

        
        public void DrawPoints() { Console.WriteLine("Points: " + Object.points); }
        public void DrawAttack() { Console.WriteLine("ATTACK!");}

        public void DrawScreen(Object player, Object enemy, Object powerUp)
        {
            Console.Clear();
            gameFrame.Draw();

            if(Program.attackMode == true)
                Console.ForegroundColor = Program.colors[Program.generadorRandoms.Next(0,15)];           
            else           
                Console.ForegroundColor = player.color;
                        
            Console.SetCursorPosition(player.x, player.y);
            player.Draw('X');

            Console.ForegroundColor = enemy.color;
            Console.SetCursorPosition(enemy.x, enemy.y);
            enemy.Draw('@');

            Console.ForegroundColor = Program.colors[10];
            Console.SetCursorPosition(Console.WindowWidth - 15, 1);
            DrawPoints();

            Console.ForegroundColor = Program.colors[10];
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
                powerUp.Draw('$');
            }

            Thread.Sleep(200);
        }



    }
}
