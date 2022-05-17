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
       
        static public ConsoleRectangle gameFrame = new ConsoleRectangle(gameFrameWidth, gameFrameHeight, mainFrameLocationPoint, GameManager.colors[14]);
        static public ConsoleRectangle attackFrame = new ConsoleRectangle(20, 2, attackFrameLocationPoint, GameManager.colors[9]);
       
        public void DrawAttack() { Console.WriteLine("ATTACK!");}

        public void DrawScreen(List<Player> players, List<Enemy> enemies, Entity powerUp)
        {
            Console.Clear();
            gameFrame.Draw();          

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].atackMode == true)
                    Console.ForegroundColor = GameManager.colors[GameManager.generadorRandoms.Next(0, 15)];
                else
                    Console.ForegroundColor = players[i].color;

                Console.SetCursorPosition(players[i].position.x, players[i].position.y);
                players[i].Draw('X');

                Console.ForegroundColor = players[i].color;
                
                Console.SetCursorPosition(5, i);
                players[i].DrawLives();
               
                Console.SetCursorPosition(Console.WindowWidth - 15, i);
                players[i].DrawPoints();

                if (players[i].atackMode == true)
                {
                    attackFrame.Draw();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 2);
                    DrawAttack();
                }

                if (LookForAtackMode(players) == false)
                {
                    Console.ForegroundColor = powerUp.color;
                    Console.SetCursorPosition(powerUp.position.x, powerUp.position.y);
                    powerUp.Draw('0');
                }                               
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                Console.ForegroundColor = enemies[i].color;
                Console.SetCursorPosition(enemies[i].position.x, enemies[i].position.y);
                enemies[i].Draw('@');
            }

            Thread.Sleep(200);
        }

        private bool LookForAtackMode(List<Player> players)
        {
            bool aux = false;

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].atackMode == true) aux = true;                                              
            }

            if (aux == true) return true;
            else return false;
        }
    }
}
