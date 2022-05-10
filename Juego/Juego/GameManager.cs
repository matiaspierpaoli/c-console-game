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
        public static List<Enemy> enemies = new List<Enemy>();

        static Entity player1 = new Player(0, 0, colors[1]);
        static Entity player2 = new Player(0, 0, colors[9]);

        static Entity enemy1 = new Enemy(0, 0, colors[4]);
        static Entity enemy2 = new Enemy(0, 0, colors[4]);
        static Entity enemy3 = new Enemy(0, 0, colors[4]);

        static Entity powerUp = new Entity(0, 0, colors[3]);
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

                for (int i = 0; i < enemies.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            enemies[i].MoveOneNormalPos();
                            break;
                        case 1:
                            enemies[i].MoveDiagonaly();
                            break;
                        case 2:
                            enemies[i].MoveInLineVerticaly();
                            break;
                        default:
                            break;
                    }
                }

                DetectCollisionPlayerAndPowerUp();

                DetectCollisionPlayerAndEnemy();

                ui.DrawScreen(players, enemies, powerUp);

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
                for (int j = 0; j < enemies.Count; j++)
                {
                    if (players[i].x == enemies[j].x && players[i].y == enemies[j].y)
                    {
                        if (players[i].atackMode == true)
                        {
                            enemies[i].RandomizePosition();
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

            enemies.Add(enemy1 as Enemy);
            enemies.Add(enemy2 as Enemy);
            enemies.Add(enemy3 as Enemy);

            for (int i = 0; i < players.Count; i++)
            {
                players[i].RandomizePosition();
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].RandomizePosition();
            }

            powerUp.RandomizePosition();
            

            MainLoop();
        }
    }
}
