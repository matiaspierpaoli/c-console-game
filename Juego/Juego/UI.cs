using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Pierpaoli_Console_Game
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
       
        public void DrawAttack() { Console.WriteLine("ATTACK!");}

        public void DrawScreen(Object player1, Object player2, Object enemy, Object powerUp)
        {
            Console.Clear();
            gameFrame.Draw();

            if(Program.attackMode == true)
                Console.ForegroundColor = Program.colors[Program.generadorRandoms.Next(0,15)];           
            else           
                Console.ForegroundColor = player1.color;
                        
            Console.SetCursorPosition(player1.x, player1.y);
            player1.Draw('X');

            if (Program.attackMode == true)
                Console.ForegroundColor = Program.colors[Program.generadorRandoms.Next(0, 15)];
            else
                Console.ForegroundColor = player2.color;

            Console.SetCursorPosition(player2.x, player2.y);
            player2.Draw('X');

            Console.ForegroundColor = enemy.color;
            Console.SetCursorPosition(enemy.x, enemy.y);
            enemy.Draw('@');

            Console.ForegroundColor = player1.color;
            Console.SetCursorPosition(Console.WindowWidth - 15, 1);
            player1.DrawPoints();

            Console.ForegroundColor = player2.color;
            Console.SetCursorPosition(Console.WindowWidth - 15, 2);
            player2.DrawPoints();

            Console.ForegroundColor = player1.color;
            Console.SetCursorPosition(5, 1);
            player1.DrawLives();

            Console.ForegroundColor = player2.color;
            Console.SetCursorPosition(5, 2);
            player2.DrawLives();

            if (Program.attackMode == true)
            {
                attackFrame.Draw();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 2);
                DrawAttack();
            }
            else
            {
                Console.ForegroundColor = powerUp.color;
                Console.SetCursorPosition(powerUp.x, powerUp.y);
                powerUp.Draw('$');
            }

            Thread.Sleep(200);
        }



    }
}
