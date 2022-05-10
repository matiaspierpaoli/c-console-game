using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierpaoli_Console_Game
{
    class GameManager
    {
        public static ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        public static List<Player> players = new List<Player>();

        static Object player1 = new Player(0, 0, colors[1]);
        static Object player2 = new Player(0, 0, colors[9]);
        static Object enemy = new Object(0, 0, colors[4]);
        static Object powerUp = new Object(0, 0, colors[3]);
        static UI ui = new UI();

        static ConsoleKeyInfo cki = Console.ReadKey();
        public static Random generadorRandoms = new Random();

        static bool winCondition = false;

        public static void MainLoop()
        {
            do
            {
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    CheckInput();
                }

                enemy.MoveEnemyOnePos();

                DetectCollisionPlayerAndPowerUp();

                DetectCollisionPlayerAndEnemy();

                ui.DrawScreen(players, enemy, powerUp);

            } while (winCondition == false);
        }

        public static void CheckInput()
        {
            for (int i = 0; i < players.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        if (cki.Key == ConsoleKey.UpArrow) { players[i].MoveUp(); }
                        else if (cki.Key == ConsoleKey.DownArrow) { players[i].MoveDown(); }
                        else if (cki.Key == ConsoleKey.LeftArrow) { players[i].MoveLeft(); }
                        else if (cki.Key == ConsoleKey.RightArrow) { players[i].MoveRight(); }
                        break;
                    case 1:
                        if (cki.Key == ConsoleKey.W) { players[i].MoveUp(); }
                        else if (cki.Key == ConsoleKey.S) { players[i].MoveDown(); }
                        else if (cki.Key == ConsoleKey.A) { players[i].MoveLeft(); }
                        else if (cki.Key == ConsoleKey.D) { players[i].MoveRight(); }
                        break;
                    default:
                        break;
                }
            }
        }

        public static void DetectCollisionPlayerAndEnemy()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].x == enemy.x && players[i].y == enemy.y)
                {
                    if (players[i].atackMode == true)
                    {
                        enemy.RandomizePosition();
                        players[i].AddPoint();
                        players[i].atackMode = false;
                        powerUp.RandomizePosition();
                    }
                    else
                    {
                        players[i].RandomizePosition();
                        players[i].TakeDamage();
                    }
                }
            }
        }

        public static void DetectCollisionPlayerAndPowerUp()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].x == powerUp.x && players[i].y == powerUp.y) { players[i].atackMode = true; }
            }
        }

        public void Run()
        {
            Console.CursorVisible = false;

            players.Add(player1 as Player);
            players.Add(player2 as Player);

            for (int i = 0; i < players.Count; i++)
            {
                players[i].RandomizePosition();
            }

            powerUp.RandomizePosition();
            enemy.RandomizePosition();

            MainLoop();
        }
    }
}
