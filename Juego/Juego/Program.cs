using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*Pierpaoli Matias - C# console game*/

namespace Pierpaoli_Console_Game
{
    class Program
    {
        public static ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        static Object player1 = new Object(0, 0, 5, 0, colors[1]);
        static Object player2 = new Object(0, 0, 5, 0, colors[9]);
        static Object enemy = new Object(0, 0, 0, 0, colors[4]);
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
                    cki = Console.ReadKey(true);
                    CheckInputFirstPlayer();                   
                    CheckInputSecondPlayer();
                }

                enemy.MoveEnemyOnePos();

                if(DetectCollisionPlayer1AndPowerUp()) { attackMode = true; }
                else if (DetectCollisionPlayer2AndPowerUp()) { attackMode = true; }

                if (DetectCollisionPlayer1AndEnemy())
                {
                    if (attackMode == true)
                    {
                        enemy.RandomizePosition();
                        player1.AddPoint();
                        attackMode = false;
                        powerUp.RandomizePosition();
                    }
                    else
                    {
                        player1.RandomizePosition();
                        player1.TakeDamage();
                    }                 
                }

                if (DetectCollisionPlayer2AndEnemy())
                {
                    if (attackMode == true)
                    {
                        enemy.RandomizePosition();
                        player2.AddPoint();
                        attackMode = false;
                        powerUp.RandomizePosition();
                    }
                    else
                    {
                        player2.RandomizePosition();
                        player2.TakeDamage();
                    }
                }

                ui.DrawScreen(player1,player2, enemy, powerUp);

            } while (winCondition == false);
        }

        static void CheckInputFirstPlayer()
        {
            if (cki.Key == ConsoleKey.UpArrow) { player1.MoveUp(); }
            else if (cki.Key == ConsoleKey.DownArrow) { player1.MoveDown(); }
            else if (cki.Key == ConsoleKey.LeftArrow) { player1.MoveLeft(); }
            else if (cki.Key == ConsoleKey.RightArrow) { player1.MoveRight(); }
        }

        static void CheckInputSecondPlayer()
        {
            if (cki.Key == ConsoleKey.W) { player2.MoveUp(); }
            else if (cki.Key == ConsoleKey.S) { player2.MoveDown(); }
            else if (cki.Key == ConsoleKey.A) { player2.MoveLeft(); }
            else if (cki.Key == ConsoleKey.D) { player2.MoveRight(); }
        }

        static bool DetectCollisionPlayer1AndEnemy()
        {
            if (player1.x == enemy.x && player1.y == enemy.y) { return true; }
            else return false;
        }

        static bool DetectCollisionPlayer2AndEnemy()
        {
            if (player2.x == enemy.x && player2.y == enemy.y) { return true; }
            else return false;
        }

        static bool DetectCollisionPlayer1AndPowerUp()
        {
            if (player1.x == powerUp.x && player1.y == powerUp.y) { return true; }
            else return false;
        }

        static bool DetectCollisionPlayer2AndPowerUp()
        {
            if (player2.x == powerUp.x && player2.y == powerUp.y) { return true; }
            else return false;
        }

        static void Run()
        {
            Console.CursorVisible = false;

            powerUp.RandomizePosition();
            player1.RandomizePosition();
            player2.RandomizePosition();
            enemy.RandomizePosition();

            MainLoop();
        }

    }
}
