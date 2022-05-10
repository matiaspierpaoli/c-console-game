using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierpaoli_Console_Game
{
    class Player : Object
    {
        public int lives { get; set; }
        public int points { get; set; }
        public bool atackMode { get; set; }

        public Player(int x, int y, ConsoleColor color): base(x, y, color)
        {
            lives = 5;
            points = 0;
            atackMode = false;
        }

        public void TakeDamage() { lives--; }
        public void AddPoint() { points++; }

        public void DrawLives() { Console.Write("Lives: " + lives); }
        public void DrawPoints() { Console.WriteLine("Points: " + points); }
    }

}
