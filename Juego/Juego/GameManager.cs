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

      
       
        static Entity player1;
        static Entity player2;

        static Entity enemy1;
        static Entity enemy2;
        static Entity enemy3;

        static Entity powerUp;
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
                    enemies[i].Move();
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
                        if (cki.Key == ConsoleKey.UpArrow) { players[i].position.y--; }
                        else if (cki.Key == ConsoleKey.DownArrow) { players[i].position.y++; }
                        else if (cki.Key == ConsoleKey.LeftArrow) { players[i].position.x--; }
                        else if (cki.Key == ConsoleKey.RightArrow) { players[i].position.x++; }
                        break;
                    case 1:
                        if (cki.Key == ConsoleKey.W) { players[i].position.y--; }
                        else if (cki.Key == ConsoleKey.S) { players[i].position.y++; }
                        else if (cki.Key == ConsoleKey.A) { players[i].position.x--; }
                        else if (cki.Key == ConsoleKey.D) { players[i].position.x++; }
                        break;
                    default:
                        break;
                }

                players[i].position.SetLimits();
            }
        }

        public static void DetectCollisionPlayerAndEnemy()
        {
            for (int i = 0; i < players.Count; i++)
            {
                for (int j = 0; j < enemies.Count; j++)
                {
                    if (players[i].position.x == enemies[j].position.x && players[i].position.y == enemies[j].position.y)
                    {
                        if (players[i].atackMode == true)
                        {
                            enemies[i].position.RandomizePosition();
                            players[i].AddPoint();
                            players[i].atackMode = false;
                            powerUp.position.RandomizePosition();
                        }
                        else
                        {
                            players[i].position.RandomizePosition();
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
                if (players[i].position.x == powerUp.position.x && players[i].position.y == powerUp.position.y) { players[i].atackMode = true; }
            }
        }

        public void Run()
        {
            Console.CursorVisible = false;

            player1 = new Player(0, 0, colors[1]);
            player2 = new Player(0, 0, colors[9]);
            
            enemy1 = new Enemy(0, 0, colors[4], new LinearMovement());
            enemy2 = new Enemy(0, 0, colors[4], new DiagonalMovement());
            enemy3 = new Enemy(0, 0, colors[4], new RandomMovement());
            
            powerUp = new Entity(0, 0, colors[3]);
            ui = new UI();

            players.Add(player1 as Player);
            players.Add(player2 as Player);

            enemies.Add(enemy1 as Enemy);
            enemies.Add(enemy2 as Enemy);
            enemies.Add(enemy3 as Enemy);

            foreach (var enemy in enemies)
            {
                enemy.position.RandomizePosition();
            }

            foreach (var player in players)
            {
                player.position.RandomizePosition();
            }

            powerUp.position.RandomizePosition();

            MainLoop();
        }
    }
}
